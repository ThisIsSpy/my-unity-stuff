using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PhysicsConstantsSO", menuName ="SO/Physics Constants SO", order = 2)]
public class PhysicsConstantsSO : ScriptableObject
{
    [SerializeField] private float _accelerationOfGravity;
    [SerializeField] private float _gravitationalConstant;

    public float AccelerationOfGravity { get { return _accelerationOfGravity; } private set { } }
    public float GravitationalConstant { get { return _gravitationalConstant; } private set { } }
}
