using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using SpellboundForest.Enums;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField] private float gameTime = 0f;
    [SerializeField] private bool isMultiplayer = false;
    [SerializeField] private GameState currentState;

    public event System.Action<GameState> OnGameStateChanged;
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

    private void InitializeGame()
    {
        DataManager.Instance.LoadMainMenu();
        SpawnManager.Instance.InitializeSpawnPoints();
        SetGameState(GameState.MainMenu);
    }

    private void SetGameState(GameState newState)
    {
        currentState = newState;
        OnGameStateChanged?.Invoke(currentState);
    }

    private void Update()
    {
        if (currentState == GameState.Playing)
        {
            gameTime += Time.deltaTime;
            CheckWinConditions();
        }
    }

    private void CheckWinConditions()
    {
        throw new NotImplementedException();
    }

    public void StartGame(bool multiplayer)
    {
        isMultiplayer = multiplayer;
        gameTime = 0f;

        SpawnManager.Instance.InitializeSpawnPoints(); // cambiar por inicializar general

        if (isMultiplayer)
        {
            SpawnManager.Instance.SpawnMultiplayerWizards();
        }
        else
        {
            SpawnManager.Instance.SpawnSinglePlayerWizard();
        }

        SetGameState(GameState.Playing);
    }

    public void GameOver(bool victory)
    {
        SetGameState(victory ? GameState.Victory : GameState.GameOver);
        DataManager.Instance.SaveHighScore(gameTime);
    }
}
