using Pinball;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{  
    public class PinballRedirector : MonoBehaviour
    {
        [SerializeField] private Vector3 launchDirection;

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out PinballLauncher _))
            {
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.velocity += launchDirection;
            }
        }
    }
}