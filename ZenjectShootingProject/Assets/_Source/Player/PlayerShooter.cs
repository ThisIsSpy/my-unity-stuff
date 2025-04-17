using BulletSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        private BulletPool bulletPool;
        private Transform bulletSpawnPos;

        [Inject]
        public void Construct(BulletPool bulletPool, Transform bulletSpawnPos)
        {
            this.bulletPool = bulletPool;
            this.bulletSpawnPos = bulletSpawnPos;
        }

        public void Shoot()
        {
            if(bulletPool.TryGetBullet(out var bullet))
            {
                Debug.Log("shooting...");
                bullet.transform.position = bulletSpawnPos.position;
                bullet.gameObject.SetActive(true);
            }
        }
    }
    
}