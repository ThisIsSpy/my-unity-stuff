using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    private Queue<Bullet> _bulletPool;
    private Bullet _bulletPrefab;
    private const int _startPoolSize = 10;
    private const int _maxPoolSize = 20;
    private int _unusedSpace;

    public BulletPool(Bullet bulletPrefab)
    {
        InitPool(bulletPrefab);
    }
    public BulletPool(Bullet[] bullets)
    {
        InitPool(bullets);
    }

    private void InitPool(Bullet bulletPrefab)
    {
        _bulletPool = new();
        for(int i = 0; i < _startPoolSize; i++)
        {
            Bullet bulletInstance = Object.Instantiate(bulletPrefab);
            bulletInstance.Construct(this);
            _bulletPool.Enqueue(bulletInstance);
        }
        _unusedSpace = _maxPoolSize - _startPoolSize;
        _bulletPrefab = bulletPrefab;
    }
    private void InitPool(Bullet[] bullets)
    {

    }
    public bool TryGetBullet(out Bullet bullet)
    {
        bullet = null;
        if (_bulletPool.Count < 1 && _unusedSpace > 0)
        {
            Bullet bulletInstance = Object.Instantiate(_bulletPrefab);
            bulletInstance.Construct(this);
            _bulletPool.Enqueue(bulletInstance);
            _unusedSpace--;
            bullet = _bulletPool.Dequeue();
            return true;
        }
        else if (_bulletPool.Count > 0)
        {
            bullet = _bulletPool.Dequeue();
            return true;
        }
        return false;
    }
    public void ReturnToPool(Bullet bullet)
    {
        _bulletPool.Enqueue(bullet);
    }
}
