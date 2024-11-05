using PlayerSystem.PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private PlayerMovementController movementController;

    private void Update()
    {
        ReadMoveInput();
    }
    private void ReadMoveInput()
    {
        movementController.InvokeMove();
    }
    public void SetController(PlayerMovementController movementController)
    {
        this.movementController = movementController;
    }
}
