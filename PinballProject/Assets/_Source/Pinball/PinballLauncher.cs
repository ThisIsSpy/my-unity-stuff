using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pinball
{
    public class PinballLauncher : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI speedHUD;
        private Rigidbody rb;
        private bool hasBeenLaunched;
        private bool hasStopped;
        private float timeWhenStopped;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            hasBeenLaunched = false;
            hasStopped = false;
            timeWhenStopped = 0;
        }

        void Update()
        {
            if(hasBeenLaunched && !hasStopped && rb.velocity == Vector3.zero)
            {
                hasStopped = true;
                timeWhenStopped = Time.time;
                Debug.Log("has stopped");
                return;
            }
            else if(!rb.IsSleeping() && hasStopped)
            {
                hasStopped = false;
                Debug.Log("has unstopped");
                return;
            }
            if(hasBeenLaunched && hasStopped && Time.time - (timeWhenStopped + 5) > 0)
            {
                rb.AddForce(Vector3.forward * 100);
                Debug.Log("launched cuz stopped for too long");
            }
        }

        public void LaunchPinball(int speed)
        {
            if (hasBeenLaunched) return;
            rb.AddRelativeForce(Vector3.forward * speed);
            StartCoroutine(SpeedAddCoroutine());
            speedHUD.text = "";
            Debug.Log("launched");
            hasBeenLaunched = true;
        }

        public void UpdateSpeedDisplay(int speed)
        {
            speedHUD.text = $"Speed: {speed}";
        }

        private IEnumerator SpeedAddCoroutine()
        {
            yield return new WaitForSeconds(5);
            rb.AddRelativeForce(Vector3.forward * 100);
            StartCoroutine(SpeedAddCoroutine());
        }
    }
}
