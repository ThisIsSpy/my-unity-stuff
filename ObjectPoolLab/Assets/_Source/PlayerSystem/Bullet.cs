using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;
    private BulletPool _bulletPool;
    private Rigidbody _rb;

    private IEnumerator DestroyOnLifetimeExpireCoroutine()
    {
        Debug.Log("coroutine started");
        yield return new WaitForSeconds(lifetime);
        Debug.Log("lifetime ended");
        this.gameObject.SetActive(false);
        Debug.Log("bullet should be disabled");
    }
    public void Construct(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(this.transform.position * speed, ForceMode.Impulse);
        StartCoroutine(DestroyOnLifetimeExpireCoroutine());

    }
    private void OnDisable()
    {
        _bulletPool.ReturnToPool(this);
    }
}
