using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameStateBase
{
    private GameMenuManager GameMenuManager => MenuManager as GameMenuManager;
    public GameOverState(GameManager gameManager, MenuManagerBase menuManager)
        : base(gameManager, menuManager) { }


    public override void Enter()
    {
        if (GameMenuManager != null)
        {
            Time.timeScale = 0f; // Pausa el tiempo del juego
            GameMenuManager.ShowGameOverMenu();
            GameMenuManager.EnableMenuControls();
        }
    }

    public override void Exit()
    {
        GameMenuManager?.HideAllMenus();
    }

    public override void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            GameManager.Instance.ReturnToMainMenu();
        }
    }
}
