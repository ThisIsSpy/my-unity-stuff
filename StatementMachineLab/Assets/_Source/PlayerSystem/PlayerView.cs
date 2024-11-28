using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody2D rb;

        public void Move(float moveSpeed)
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            float yMove = Input.GetAxisRaw("Vertical");
            rb.transform.position += new Vector3(xMove, yMove, 0) * moveSpeed;
        }
        public void Construct(Rigidbody2D rb)
        {
            this.rb = rb;
        }
    }
}
