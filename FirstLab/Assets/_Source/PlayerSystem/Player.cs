using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public GameObject Bullet { get; private set; }

    private Rigidbody _rb;
    public Rigidbody Rb => _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

}
