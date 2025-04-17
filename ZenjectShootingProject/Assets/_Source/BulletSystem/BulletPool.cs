using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletSystem
{
    public class BulletPool
    {
        private readonly Queue<Bullet> bulletPool;
        private readonly List<Bullet> bullets;
        private readonly BulletSpawner bulletSpawner;

        public Queue<Bullet> BulletQueue { get { return bulletPool; } private set { } }

        public BulletPool(BulletSpawner bulletSpawner)
        {
            this.bulletSpawner = bulletSpawner;
            bulletPool = new Queue<Bullet>();
            bullets = new List<Bullet>();
            InitPool(10);
        }

        public void InitPool(int maxShots)
        {
            Debug.Log("starting pool init");
            for(int i = 0; i < maxShots; i++)
            {
                Bullet spawnedBullet = bulletSpawner.Spawn();
                spawnedBullet.InjectOwnerPool(this);
                bulletPool.Enqueue(spawnedBullet);
                bullets.Add(spawnedBullet);
            }
        }

        public bool TryGetBullet(out Bullet bullet)
        {
            bullet = null;
            if (bulletPool.Count > 0)
            {
                bullet = bulletPool.Dequeue();
                return true;
            }
            return false;
        }
        public void ReturnToPool(Bullet bullet)
        {
            bulletPool.Enqueue(bullet);
        }
        public void ClearPool()
        {
            foreach (var part in bullets)
            {
                Object.Destroy(part.gameObject);
            }
            bulletPool.Clear();
            bullets.Clear();
        }
    }
}