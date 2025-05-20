using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flippers
{
    public class Flipper : MonoBehaviour
    {
        private HingeJoint joint;

        void Start()
        {
            joint = GetComponent<HingeJoint>();
        }

        public void RotateFlipper()
        {
            StartCoroutine(FlipperCoroutine());
        }

        private IEnumerator FlipperCoroutine()
        {
            var motor = joint.motor;
            joint.useMotor = true;
            yield return new WaitForSeconds(0.1f);
            motor.targetVelocity = -motor.targetVelocity;
            joint.motor = motor;
            yield return new WaitForSeconds(0.1f);
            motor.targetVelocity = -motor.targetVelocity;
            joint.motor = motor;
            joint.useMotor = false;
        }
    }
}