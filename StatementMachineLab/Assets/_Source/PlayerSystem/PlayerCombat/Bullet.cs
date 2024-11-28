using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float speed;

    private IEnumerator BulletCoroutine()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0, speed), ForceMode2D.Impulse);
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
    private void Awake()
    {
        StartCoroutine(BulletCoroutine());
    }
}
