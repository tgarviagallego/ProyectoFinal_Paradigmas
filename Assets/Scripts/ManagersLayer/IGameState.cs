using System.Collections;
using System.Collections.Generic;

public interface IGameState
{
    void Enter();
    void Exit();
    void Update();
}
