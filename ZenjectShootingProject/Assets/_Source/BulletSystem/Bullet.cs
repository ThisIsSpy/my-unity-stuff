using Destructibles;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifetime = 2.5f;
        [SerializeField] private float speed = 60f;
        private AudioClip[] sounds;
        private SoundPlayer soundPlayer;
        private BulletPool bulletPool;
        private Rigidbody2D rb;

        [Inject]
        public void Construct(AudioClip[] sounds, SoundPlayer soundPlayer)
        {
            this.sounds = sounds;
            this.soundPlayer = soundPlayer;
        }

        public void InjectOwnerPool(BulletPool bulletPool)
        {
            this.bulletPool = bulletPool;
        }

        void OnEnable()
        {
            if(rb == null) rb = GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(new(speed, 0));
            soundPlayer.PlaySound(sounds[0]);
            StartCoroutine(LifetimeCoroutine());
        }

        void OnDisable()
        {
            rb.velocity = Vector3.zero;
            bulletPool.ReturnToPool(this);
            StopAllCoroutines();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out DestructibleObject DO))
            {
                StartCoroutine(CollisionCoroutine());
                DO.Destruction();
                Debug.Log("destruction should have happened");
            }
        }

        private IEnumerator LifetimeCoroutine()
        {
            yield return new WaitForSeconds(lifetime);
            gameObject.SetActive(false);
        }

        private IEnumerator CollisionCoroutine()
        {
            soundPlayer.PlaySound(sounds[1]);
            yield return new WaitForSeconds(sounds[1].length + 0.05f);
            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<Bullet>
        {

        }
    }
}