using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    private BulletPool _bulletPool;
    public void Construct(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void Shoot()
    {
        if(_bulletPool.TryGetBullet(out var bullet))
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = firePoint.position;
        }
    }
}
