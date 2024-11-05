using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem.PlayerMovement
{
    public class PlayerMovementController : MonoBehaviour
    {
        public PlayerMovementModel model;
        public PlayerMovementView view;
        public Rigidbody2D rb;
        public void InvokeMove()
        {
            view.Move(rb,model.Speed);
        }
    }
}
