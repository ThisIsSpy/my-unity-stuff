using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private PlayerInvoker _invoker;
        private HUDChanger _hudChanger;
        private bool _isMovementActive = true;
        void Update()
        {
            if (_isMovementActive)
            {
                ReadJumpInput();
                ReadMoveInput();
            }
            ReadDisableInput();
        }
        private void ReadJumpInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _invoker.InvokeJump();
            }
        }
        private void ReadMoveInput()
        {
            _invoker.InvokeMove();
        }
        private void ReadDisableInput()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _isMovementActive = !_isMovementActive;
                Debug.Log(_isMovementActive);
                _hudChanger.ChangeText(_isMovementActive);
            }
        }
        private void ReadShootInput()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _invoker.InvokeShoot();
            }
        }
        public void SetInvoker(PlayerInvoker invoker)
        {
            _invoker = invoker;
            Debug.Log("Invoker set");
        }
        public void SetHUDChanger(HUDChanger changer)
        {
            _hudChanger = changer;
            Debug.Log("Changer set");
        }
    }
}

