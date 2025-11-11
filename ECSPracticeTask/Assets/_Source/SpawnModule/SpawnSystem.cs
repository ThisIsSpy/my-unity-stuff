using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct SpawnSystem : ISystem
{
    public struct SpawnedTag : IComponentData { }
    public struct SpawnedEntityTag : IComponentData { }

    [BurstCompile]
    public void OnUpdate(ref SystemState systemState)
    {
        if (!SystemAPI.HasSingleton<Spawner>()) return;

        Entity spawnerEntity = SystemAPI.GetSingletonEntity<Spawner>();
        if (systemState.EntityManager.HasComponent<SpawnedTag>(spawnerEntity)) return;
        var spawner = SystemAPI.GetSingleton<Spawner>();
        if (spawner.Prefab == null) return;
        float3 planeSize = new(28, 0, 28);
        var entityManager = systemState.EntityManager;
        NativeArray<Entity> clones = entityManager.Instantiate(spawner.Prefab, spawner.Count, Allocator.Temp);
        for (int i = 0; i < clones.Length; i++)
        {
            float3 pos = new(UnityEngine.Random.Range(-planeSize.x, planeSize.x), 1, UnityEngine.Random.Range(-planeSize.z, planeSize.z));
            quaternion rot = Quaternion.Euler(0,UnityEngine.Random.Range(0f, 360f),0);
            LocalTransform localTransform = entityManager.GetComponentData<LocalTransform>(clones[i]);
            localTransform.Position = pos;
            localTransform.Rotation = rot;
            TargetRotation targetRot = new() { Value = rot };
            TargetPosition targetPos = new() { Value = pos };
            TimerTag timer = new() { Timer = 0f, TimerLimit = UnityEngine.Random.Range(3f, 7f) };
            entityManager.AddComponent<SpawnedEntityTag>(clones[i]);
            entityManager.AddComponent<TargetRotation>(clones[i]);
            entityManager.AddComponent<TargetPosition>(clones[i]);
            entityManager.AddComponent<TimerTag>(clones[i]);
            entityManager.SetComponentData(clones[i], localTransform);
            entityManager.SetComponentData(clones[i], targetRot);
            entityManager.SetComponentData(clones[i], targetPos);
            entityManager.SetComponentData(clones[i], timer);
        }
        entityManager.AddComponent<SpawnedTag>(spawnerEntity);
        clones.Dispose();
    }
}
