using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance => _instance;

    private GameSettings gameSettings;
    private List<float> highScores = new List<float>();

    internal void LoadMainMenu()
    {
        throw new NotImplementedException();
    }

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



    public void LoadGameSettings()
    {
        if (PlayerPrefs.HasKey("GameSettings"))
        {
            string json = PlayerPrefs.GetString("GameSettings");
            gameSettings = JsonUtility.FromJson<GameSettings>(json);
        }
        else
        {
            gameSettings = new GameSettings();
            SaveGameSettings();
        }
    }

    public void SaveGameSettings()
    {
        string json = JsonUtility.ToJson(gameSettings);
        PlayerPrefs.SetString("GameSettings", json);
        PlayerPrefs.Save();
    }

    public void SaveHighScore(float time)
    {
        highScores.Add(time);
        highScores.Sort();
        if (highScores.Count > 10) // Mantener solo los 10 mejores
        {
            highScores.RemoveAt(highScores.Count - 1);
        }
        SaveHighScores();
    }

    private void SaveHighScores()
    {
        PlayerPrefs.SetString("HighScores", JsonUtility.ToJson(new { scores = highScores }));
        PlayerPrefs.Save();
    }
}
