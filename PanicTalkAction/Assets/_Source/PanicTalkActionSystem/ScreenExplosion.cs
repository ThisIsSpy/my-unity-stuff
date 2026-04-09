using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PanicTalkAction.PanicTalkActionSystem
{
    public class ScreenExplosion : MonoBehaviour
    {
        [SerializeField] private float explosionForce, explosionRadius = 10f;
        [SerializeField] private Transform explosionPositionTransform;
        private void Awake()
        {
            List<Transform> childrenTransform = GetComponentsInChildren<Transform>().ToList();
            foreach(Transform child in childrenTransform)
            {
                if(child.TryGetComponent(out Rigidbody childRigidBody))
                {
                    childRigidBody.AddExplosionForce(explosionForce, explosionPositionTransform.position, explosionRadius);
                }
            }
        }
    }
}
