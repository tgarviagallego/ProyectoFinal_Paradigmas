using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : GameStateBase
{
    private MainMenuManager MainMenuManager => MenuManager as MainMenuManager;

    public MainMenuState(GameManager gameManager, MenuManagerBase menuManager)
        : base(gameManager, menuManager) { }

    public override void Enter()
    {
        if (MainMenuManager != null)
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
            MainMenuManager.ShowMainMenu();
            MainMenuManager.EnableMenuControls();
        }
    }

    public override void Exit()
    {
        MainMenuManager?.HideAllMenus();
    }
}
