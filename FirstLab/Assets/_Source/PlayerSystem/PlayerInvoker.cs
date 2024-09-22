using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvoker
{
    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private Player _player;

    public PlayerInvoker(Player player)
    {
        _playerMovement = new();
        _playerCombat = new();
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
        Debug.Log("shoot invoked");
        _playerCombat.Shoot(_player.Bullet, _player);
    }
}
