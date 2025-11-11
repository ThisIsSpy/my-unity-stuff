using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MovementAuthorization : MonoBehaviour
{
    public float MinMovementSpeed;
    public float MaxMovementSpeed;
    public float MinRotationSpeed;
    public float MaxRotationSpeed;
    public float MinWaitingTime;
    public float MaxWaitingTime;
}

public struct MovementSpeed : IComponentData { public float MinValue, MaxValue; }
public struct RotationSpeed : IComponentData { public float MinValue, MaxValue; }
public struct TimerTag : IComponentData { public float Timer, TimerLimit; }
public struct TargetRotation : IComponentData { public quaternion Value; }
public struct TargetPosition :  IComponentData { public Vector3 Value; }