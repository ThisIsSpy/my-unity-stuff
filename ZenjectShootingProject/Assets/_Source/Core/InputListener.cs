using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        private PlayerShooter playerShooter;

        [Inject]
        public void Construct(PlayerShooter playerShooter)
        {
            this.playerShooter = playerShooter;
        }

        void Update()
        {
            if(playerShooter == null) return;
            ListenForShootInput();
        }

        private void ListenForShootInput()
        {
            if(Input.GetMouseButtonDown(0))
            {
                playerShooter.Shoot();
            }
        }
    }
}
