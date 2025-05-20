using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private float interval = 1f;
    private HingeJoint joint;

    private void Awake()
    {
        joint = GetComponent<HingeJoint>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(Inverter), 0f, interval);
    }
    private void Inverter()
    {
        var motor = joint.motor;
        motor.targetVelocity *= -1;
        joint.motor = motor;
    }
}
