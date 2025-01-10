using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : GameStateBase
{
    private MainMenuManager MainMenuManager => MenuManager as MainMenuManager;

    public MainMenuState(GameManager gameManager, MenuManagerBase menuManager)
        : base(gameManager, menuManager) { }

    public override void Enter()
    {
        if (MainMenuManager != null)
        {
            MainMenuManager.ShowMainMenu();
            MainMenuManager.EnableMenuControls();
        }
    }

    public override void Exit()
    {
        MainMenuManager?.HideAllMenus();
    }
}
