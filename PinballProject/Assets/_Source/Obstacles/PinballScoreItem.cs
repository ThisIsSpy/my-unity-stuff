using Pinball;
using Score;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacles
{
    public class PinballScoreItem : MonoBehaviour
    {
        private ScoreCounter scoreCounter;
        [SerializeField] private bool addForce;
        [SerializeField] private bool deleteOnCollision;
        [SerializeField] private int scoreAddedOnHit;

        void Start()
        {
            scoreCounter = FindObjectOfType<ScoreCounter>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PinballLauncher _))
            {
                Debug.Log("collided");
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                if(addForce) rb.AddRelativeForce(new(0,0,100));
                if (scoreCounter != null) scoreCounter.Score += scoreAddedOnHit;
                if (deleteOnCollision) Destroy(this.gameObject);
            }
        }
    }
}