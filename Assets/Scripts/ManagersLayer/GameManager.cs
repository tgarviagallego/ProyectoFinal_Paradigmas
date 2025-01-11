using SpellboundForest.Enums;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private Dictionary<GameState, IGameState> states;
    private IGameState currentState;
    private string gameSceneName = "GameScene";
    private string mainMenuSceneName = "MainMenu";
    private SpawnManager spawnManager;
    private Camera mainCamera;
    public Camera MainCamera => mainCamera;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeStatesForMainMenu();
    }

    private void InitializeStatesForMainMenu()
    {
        states = new Dictionary<GameState, IGameState>
        {
            { GameState.MainMenu, new MainMenuState(this, MainMenuManager.Instance) }
        };
        SetState(GameState.MainMenu);
    }

    private void InitializeStatesForGameScene()
    {
        GameMenuManager gameMenuManager = GameMenuManager.Instance;
        states = new Dictionary<GameState, IGameState>
        {
            { GameState.MainMenu, new MainMenuState(this, MainMenuManager.Instance)},
            { GameState.Playing, new PlayingState(this, gameMenuManager) },
            { GameState.Paused, new PausedState(this, gameMenuManager) },
            { GameState.Victory, new VictoryState(this, gameMenuManager) },
            { GameState.GameOver, new GameOverState(this, gameMenuManager) }
        };
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Treasure.OnTreasureFound += HandleTreasureFound;
        PlayerState.OnPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Treasure.OnTreasureFound -= HandleTreasureFound;
        PlayerState.OnPlayerDeath -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath(bool isPlayerDeath)
    {
        if (isPlayerDeath)
        {
            SetState(GameState.GameOver);
        }
    }

    private void HandleTreasureFound(bool found)
    {
        if (found)
        {
            SetState(GameState.Victory);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == gameSceneName)
        {
            InitializeStatesForGameScene();
            StartCoroutine(InitializeGameSceneAsync());
            SetState(GameState.Playing);
        }
        else if (scene.name == mainMenuSceneName)
        {
            InitializeStatesForMainMenu();
            SetState(GameState.MainMenu);
        }
    }

    private IEnumerator InitializeGameSceneAsync()
    {
        yield return null;

        spawnManager = FindObjectOfType<SpawnManager>();

        if (spawnManager == null)
        {
            Debug.LogError("No se pudo encontrar SpawnManager en la escena del juego!");
            yield break;
        }

        GameObject wizard = GameObject.Find("Wizard1");
        spawnManager.SpawnWizard();
        spawnManager.SpawnTreasure();
    }

    private void Update()
    {
        currentState?.Update();
    }

    public void SetState(GameState newState)
    {
        if (states.TryGetValue(newState, out IGameState state))
        {
            currentState?.Exit();
            currentState = state;
            currentState.Enter();
            OnGameStateChanged?.Invoke(newState);
        }
    }

    public void StartGame()
    {
        LoadGameScene();
        SetState(GameState.Playing);
    }

    private void LoadGameScene()
    {
        if (MainMenuManager.Instance != null)
        {
            MainMenuManager.Instance.HideAllMenus();
        }

        if (spawnManager != null)
        {
            spawnManager.Wizards.Clear();
            if (spawnManager.Treasure != null)
            {
                Destroy(spawnManager.Treasure);
            }
        }

        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    public void ReturnToMainMenu()
    {
        if (spawnManager != null)
        {
            spawnManager.Wizards.Clear();
            if (spawnManager.Treasure != null)
            {
                Destroy(spawnManager.Treasure);
            }
        }
        SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
    }
}