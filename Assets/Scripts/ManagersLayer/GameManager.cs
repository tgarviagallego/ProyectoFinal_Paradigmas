using SpellboundForest.Enums;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private float gameTime;
    private bool isMultiplayer;
    private Dictionary<GameState, IGameState> states;
    private IGameState currentState;
    private string gameSceneName = "GameScene";
    private string mainMenuSceneName = "MainMenu";

    public static event Action<GameState> OnGameStateChanged;
    public float GameTime => gameTime;

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
        // Inicializar estados con el MainMenuManager
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
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == gameSceneName)
        {
            InitializeStatesForGameScene();
            SetState(GameState.Playing);
        }
        else if (scene.name == mainMenuSceneName)
        {
            InitializeStatesForMainMenu();
        }
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
        gameTime = 0f;
        LoadGameScene();
    }

    public void UpdateGameTime(float time)
    {
        gameTime = time;
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void GameOver(bool victory)
    {
        SetState(victory ? GameState.Victory : GameState.GameOver);
    }
}