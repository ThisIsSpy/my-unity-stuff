using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public PlayerShoot PlayerShoot;
    void Update()
    {
        ListenForShootInput();
    }
    private void ListenForShootInput()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PlayerShoot.Shoot();
        }
    }
}
