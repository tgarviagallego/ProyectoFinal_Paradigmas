using System.Collections;
using System.Collections.Generic;

public abstract class GameStateBase : IGameState
{
    protected GameManager GameManager { get; private set; }
    protected MenuManagerBase MenuManager { get; private set; }

    protected GameStateBase(GameManager gameManager, MenuManagerBase menuManager)
    {
        GameManager = gameManager;
        MenuManager = menuManager;
    }

    public abstract void Enter();
    public abstract void Exit();
    public virtual void Update() { }
}