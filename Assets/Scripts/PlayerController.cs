using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStateController stateController;
    private Rigidbody playerRb;

    [Header("Settings")]
    [SerializeField] private float movementSpeed;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        stateController = GetComponent<PlayerStateController>();
    }

    void Update()
    {
        SetMovementDirection();
        SetPlayerState();
        PlayerBehaviour();
    }
    private void PlayerBehaviour()
    {
        var currentState = stateController.GetCurrentState();
        switch(currentState)
        {
            case PlayerStateController.PlayerStates.Idle:
                break;
            case PlayerStateController.PlayerStates.Move:
                Movement();
                break;
        }
    }
    private void SetPlayerState()
    {
        if (movementDirection.magnitude > 0.1f)
            stateController.ChangePlayerState(PlayerStateController.PlayerStates.Move);
        else
            stateController.ChangePlayerState(PlayerStateController.PlayerStates.Idle);
    }
    private void SetMovementDirection()
    {
        horizontalInput = Input.GetAxisRaw(Consts.GameInputs.HORIZONTAL_INPUT);
        verticalInput = Input.GetAxisRaw(Consts.GameInputs.VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
    }
    private void Movement()
    {
        playerRb.velocity = movementDirection * movementSpeed;
    }
}
