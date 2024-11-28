using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerModel
    {
        private float moveSpeed;

        public float MoveSpeed
        {
            get { return moveSpeed; }
            set
            {
                if (value <= 0)
                {
                    moveSpeed = 0.01f;
                }
                else
                {
                    moveSpeed = value;
                }
            }
        }

        public PlayerModel(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }
    }
}

