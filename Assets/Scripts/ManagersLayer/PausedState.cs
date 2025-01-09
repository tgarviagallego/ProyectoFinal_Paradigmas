using SpellboundForest.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedState : GameStateBase
{
    private GameMenuManager GameMenuManager => MenuManager as GameMenuManager;

    public PausedState(GameManager gameManager, MenuManagerBase menuManager)
        : base(gameManager, menuManager) { }

    public override void Enter()
    {
        if (GameMenuManager != null)
        {
            GameMenuManager.ShowPauseMenu();
            GameMenuManager.EnableMenuControls();
        }
    }

    public override void Exit()
    {
        GameMenuManager?.HideAllMenus();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Intentando reanudar"); // Para debuggear
            GameManager.SetState(GameState.Playing);
        }
    }
}