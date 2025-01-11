using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellboundForest.Enums;

public class PlayingState : GameStateBase
{
    private GameMenuManager GameMenuManager => MenuManager as GameMenuManager;

    public PlayingState(GameManager gameManager, MenuManagerBase menuManager)
        : base(gameManager, menuManager)
    {
    }

    public override void Enter()
    {
        if (GameMenuManager != null)
        {
            GameMenuManager.HideAllMenus();
            GameMenuManager.EnableGameplayControls();
        }
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.SetState(GameState.Paused);
        }
    }
}