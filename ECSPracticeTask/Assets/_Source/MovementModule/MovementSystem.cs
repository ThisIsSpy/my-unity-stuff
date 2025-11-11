using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct MovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState systemState)
    {
        foreach(var (movementSpeed, rotationSpeed, timer, targetRot, targetPos, localTransform) in SystemAPI.Query<RefRW<MovementSpeed>, RefRW<RotationSpeed>, RefRW<TimerTag>, RefRW<TargetRotation>, RefRW<TargetPosition>, RefRW<LocalTransform>>())
        {
            timer.ValueRW.Timer += (SystemAPI.Time.DeltaTime * 5);
            if (timer.ValueRW.Timer >= timer.ValueRW.TimerLimit)
            {
                targetRot.ValueRW.Value = Quaternion.Euler(0, UnityEngine.Random.Range(0.1f, 359.9f), 0);

                float newXPos = localTransform.ValueRW.Position.x + UnityEngine.Random.Range(-5f, 5f);
                float newZPos = localTransform.ValueRW.Position.z + UnityEngine.Random.Range(-5f, 5f);
                if (newXPos < -38f) newXPos = -37.99f;
                if (newXPos > 38f) newXPos = 37.99f;
                if (newZPos < -38f) newZPos = -37.99f;
                if (newZPos > 38f) newZPos = 37.99f;
                targetPos.ValueRW.Value = new(newXPos, localTransform.ValueRW.Position.y, newZPos);

                timer.ValueRW.Timer = 0;
            }
            if (UnityEngine.Random.Range(0,2) == 1)
            {
                Rotation.RotateTowards(localTransform.ValueRW.Rotation, targetRot.ValueRW.Value, 45 * SystemAPI.Time.DeltaTime);
            }
            float moveSpeed = UnityEngine.Random.Range(movementSpeed.ValueRW.MinValue, movementSpeed.ValueRW.MaxValue);
            localTransform.ValueRW.Position = math.lerp(localTransform.ValueRW.Position, targetPos.ValueRW.Value, moveSpeed);
            
        }
    }
}
