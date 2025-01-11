using SpellboundForest.Enums;
using UnityEngine;

public class PausedState : GameStateBase
{
    private GameMenuManager GameMenuManager => MenuManager as GameMenuManager;

    public PausedState(GameManager gameManager, MenuManagerBase menuManager)
        : base(gameManager, menuManager) { }

    public override void Enter()
    {
        if (GameMenuManager != null)
        {
            Time.timeScale = 0f; // Pausa el tiempo del juego
            GameMenuManager.ShowPauseMenu();
            GameMenuManager.EnableMenuControls();
        }
    }

    public override void Exit()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        GameMenuManager?.HideAllMenus();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.SetState(GameState.Playing);
        }
    }
}