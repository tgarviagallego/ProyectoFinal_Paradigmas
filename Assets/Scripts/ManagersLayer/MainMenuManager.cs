using SpellboundForest.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager : MenuManagerBase
{
    private static MainMenuManager _instance;
    public static MainMenuManager Instance => _instance;

    [SerializeField] private MainMenu mainMenu;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(menuCanvas);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowMainMenu()
    {
        menuCanvas.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }

    public override void HideAllMenus()
    {
        menuCanvas.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }

    public override void EnableMenuControls()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}