using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private PlayerShoot playerShoot;
        [SerializeField] private InputListener inputListener;
        private BulletPool _bulletPool;
        private void Start()
        {
            _bulletPool = new(bulletPrefab);
            playerShoot.Construct(_bulletPool);
            inputListener.PlayerShoot = playerShoot;
        }
    }
}
