using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct MovementJob : IJobEntity
{
    public float Time;
    public float RandomAngle;
    public float RandomDeltaXPos;
    public float RandomDeltaZPos;
    public float RandomWaitingInterval;
    public Unity.Mathematics.Random Random;

    public void Execute()
    {

    }
    //public void Execute(ref LocalTransform localTransform, in RotationSpeed rotationSpeed, in MovementSpeed movementSpeed, in WaitingInterval waitingInterval)
    //{

    //    //if (Time % Random.NextFloat(waitingInterval.MinValue, waitingInterval.MaxValue) != 0)
    //    if(Time % RandomWaitingInterval == 2)
    //    {
    //        Debug.Log("Check Failed!");
    //        return;
    //    }
    //    else Debug.Log("Check complete!");
    //    if (true)
    //    {
    //        Debug.Log("Rotating");
    //        float angle = RandomAngle;
    //        Debug.Log($"{angle}");
    //        Quaternion newRotation = Quaternion.Euler(0, angle, 0);
    //        //localTransform = localTransform.Rotate(math.slerp(localTransform.Rotation, newRotation, Random.NextFloat(rotationSpeed.MinValue, rotationSpeed.MaxValue)));
    //        localTransform.Rotation = newRotation;
    //        //Debug.Log($"{newRotation.eulerAngles}");
    //    }
    //    float deltaXPos = RandomDeltaXPos;
    //    float deltaZPos = RandomDeltaZPos;
    //    float3 newPosition = new(localTransform.Position.x + deltaXPos, localTransform.Position.y, localTransform.Position.z + deltaZPos);
    //    localTransform.Position = math.lerp(localTransform.Position, newPosition, Random.NextFloat(movementSpeed.MinValue, movementSpeed.MaxValue));
    //}
}
