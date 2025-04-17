using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletSystem
{
    public class BulletSpawner
    {
        private readonly Bullet.Factory bulletFactory;

        public BulletSpawner(Bullet.Factory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
        }

        public Bullet Spawn()
        {
            Debug.Log("spawn function called, the bullet should have been instantiated");
            return bulletFactory.Create();
        }
    }
}