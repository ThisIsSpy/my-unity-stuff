using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem.PlayerMovement
{
    public class PlayerMovementView : MonoBehaviour
    {
        public void Move(Rigidbody2D rb, float movementSpeed)
        {
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");
            rb.velocity = new Vector2 (xMove, yMove) * movementSpeed;
        }
    }
}
