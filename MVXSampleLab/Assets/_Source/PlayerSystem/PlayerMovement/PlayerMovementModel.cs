using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem.PlayerMovement
{
    public class PlayerMovementModel
    {
        public float Speed { get; private set; }

        public PlayerMovementModel(float speed)
        {
            Speed = speed;
        }
    }
}
