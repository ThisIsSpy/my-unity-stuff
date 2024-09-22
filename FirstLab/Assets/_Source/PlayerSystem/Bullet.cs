using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Lifetime { get; private set; } = 2.0f;
    public float Speed { get; private set; } = 2.0f;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
