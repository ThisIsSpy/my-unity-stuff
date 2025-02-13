using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMover
{
    public class PlayerMover
    {
        private readonly GameObject player;
        private readonly Stack<Vector2> lastPosition;

        public PlayerMover(GameObject player)
        {
            this.player = player;
            lastPosition = new();
        }

        public void MovePlayer(Vector2 position)
        {
            lastPosition.Push(player.transform.position);
            player.transform.position = position;
        }

        public void UnmovePlayer()
        {
            if(lastPosition.Peek() != null)
            {
                player.transform.position = lastPosition.Pop();
            }
            else
            {
                Debug.LogError("pos is null");
            }
        }
    }
    
}
