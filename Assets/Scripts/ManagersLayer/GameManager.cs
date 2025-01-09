using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using SpellboundForest.Enums;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    
    public static GameManager Instance => _instance;

    [SerializeField] private float gameTime = 0f;
    [SerializeField] private bool isMultiplayer = false;
    [SerializeField] private GameState currentState;
    [SerializeField] private MenuManager menuManager;

    private string gameSceneName = "GameScene";

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
        UpdateGameState(GameState.MainMenu);
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;  // Suscribirse al evento de carga de escena
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Desuscribirse al evento
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == gameSceneName)
        {
            // Inicializar la escena del juego
            UpdateGameState(GameState.Playing);
            menuManager = FindObjectOfType<MenuManager>();
        }
    }
    public void UpdateGameState(GameState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                HandleMainMenuState();
                break;
            case GameState.Playing:
                HandlePlayingState();
                break;
            case GameState.Paused:
                HandlePausedState();
                break;
            case GameState.Victory:
                HandleVictoryState();
                break;
            case GameState.GameOver:
                HandleGameOverState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleGameOverState()
    {
        throw new NotImplementedException();
    }

    private void HandleVictoryState()
    {
        throw new NotImplementedException();
    }

    private void HandlePausedState()
    {
        menuManager.ShowPauseMenu();
        menuManager.EnableMenuControls();
    }

    private void HandlePlayingState()
    {
        if (menuManager != null)
        {
            menuManager.HideAllMenus();
            menuManager.EnableGameplayControls();
        }
    }

    private void HandleMainMenuState()
    {
        return;
        //if (menuManager != null)
        //{
        //    menuManager.ShowMainMenu();
        //    menuManager.EnableMenuControls();
        //}
    }

    private void Update()
    {
        if (currentState == GameState.Playing)
        {
            gameTime += Time.deltaTime;
            CheckWinConditions();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (currentState == GameState.Playing)
            {
                UpdateGameState(GameState.Paused);
            }
            else if (currentState == GameState.Paused)
            {
                UpdateGameState(GameState.Playing);
            }
        }
    }

    private void CheckWinConditions()
    {
        // throw new NotImplementedException();
    }

    public void StartGame()
    {
        gameTime = 0f;

        LoadGameScene();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void GameOver(bool victory)
    {
        UpdateGameState(victory ? GameState.Victory : GameState.GameOver);
        DataManager.Instance.SaveHighScore(gameTime);
    }
}
