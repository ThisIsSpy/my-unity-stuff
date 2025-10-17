using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static SpawnSystem;

[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float Time;

    public void Execute(ref LocalTransform transform, in MoveSpeed moveSpeed, in Radius radius, in AnchorPos anchorPos )
    {
        float angle = Time * moveSpeed.Value;
        float x = anchorPos.Value.x + radius.Value * math.cos(angle);
        float z = anchorPos.Value.z + radius.Value * math.sin(angle);
        transform = transform.WithPosition(new float3(x, 0, z));
    }
}
