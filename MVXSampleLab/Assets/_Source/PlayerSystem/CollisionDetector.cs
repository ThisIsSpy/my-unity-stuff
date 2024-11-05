using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class CollisionDetector : MonoBehaviour
    {
        public PlayerModel player;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Harmful")
            {
                player.HP--;
            }
        }
    }
}
