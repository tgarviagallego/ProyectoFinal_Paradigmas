using SpellboundForest.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private CharacterState currentState;

    public void ChangeState(CharacterState state)
    {
        currentState = state;
        OnStateChanged();
    }

    protected virtual void OnStateChanged() { }
}
