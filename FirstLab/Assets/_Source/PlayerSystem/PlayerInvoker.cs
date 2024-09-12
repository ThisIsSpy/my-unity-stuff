using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvoker
{
    private PlayerMovement _playerMovement;
    private Player _player;

    public PlayerInvoker(Player player)
    {
        _playerMovement = new();
        _player = player;
    }
    public void InvokeJump()
    {
        _playerMovement.Jump(_player.Rb, _player.JumpForce);
    }
    public void InvokeMove()
    {
        _playerMovement.Move(_player.Rb, _player.MovementSpeed);
    }
    public void InvokeRotate()
    {
        _playerMovement.Rotate(_player.Rb, _player.RotationSpeed);
    }
    public void InvokeShoot()
    {
        _playerMovement.Shoot();
    }
}
