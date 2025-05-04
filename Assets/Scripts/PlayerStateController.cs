using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStateController : MonoBehaviour
{
    public static event Action<PlayerStates, PlayerStates> OnStateChanged;
    public enum PlayerStates
    {
        Idle,
        Move,
    }

    private PlayerStates currentState;
    void Start()
    {
        currentState = PlayerStates.Idle;
    }

    private void SetPlayerStates(PlayerStates newState)
    {
        var previousState = currentState;
        if (previousState == newState)
            return;

        currentState = newState;
        OnStateChanged?.Invoke(previousState, newState);
    }
}
