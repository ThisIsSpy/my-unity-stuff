using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Destructibles
{
    public class DestructibleObject : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private ParticleSystem explosionParticleSystem;
        private Collider2D objectCollider;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            explosionParticleSystem = GetComponentInChildren<ParticleSystem>();
            objectCollider = GetComponent<Collider2D>();
        }

        public void Destruction()
        {
            StartCoroutine(DestructionCoroutine());
        }

        private IEnumerator DestructionCoroutine()
        {
            objectCollider.enabled = false;
            spriteRenderer.enabled = false;
            explosionParticleSystem.Play();
            yield return new WaitForSeconds(explosionParticleSystem.main.duration + 0.05f);
            Destroy(gameObject);
        }
    }
}