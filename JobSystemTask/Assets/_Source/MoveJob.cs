using UnityEngine;
using UnityEngine.Jobs;

public struct MoveJob : IJobParallelForTransform
{
    public float Radius;
    public float Speed;
    public float Time;
    public void Execute(int index, TransformAccess transform)
    {
        float angle = Time * Speed * index * .1f;
        float x = Radius * Mathf.Cos(angle);
        float y = Radius * Mathf.Sin(angle);
        //transform.position = new Vector3(x, 0, z);
        transform.position = Quaternion.AngleAxis(index, Vector3.up) * new Vector3(x, y);
    }
}
