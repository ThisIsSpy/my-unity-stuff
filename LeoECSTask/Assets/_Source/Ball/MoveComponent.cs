using UnityEngine;

public struct MoveComponent
{
    public float forwardSpeed;
    public float amplitude;
    public float frequency;
    public int direction;
    public float timer;
    public float timerLimit;
}

public struct Position
{
    public Vector3 position;
}

public struct ViewReference
{
    public Transform transform;
}