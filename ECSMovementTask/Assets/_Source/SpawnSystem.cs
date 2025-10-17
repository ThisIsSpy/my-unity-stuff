using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.UniversalDelegates;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct SpawnSystem : ISystem
{
    public struct SpawnedTag : IComponentData { }
    public struct AnchorPos : IComponentData { public float3 Value; }

    [BurstCompile]
    public void OnUpdate(ref SystemState systemState)
    {
        if (!SystemAPI.HasSingleton<Spawner>()) return;

        Entity spawnerEntity = SystemAPI.GetSingletonEntity<Spawner>();
        if(systemState.EntityManager.HasComponent<SpawnedTag>(spawnerEntity)) return;
        var spawner = SystemAPI.GetSingleton<Spawner>();
        if (spawner.Prefab == null) return;
        float x = 0f;
        float z = 0f;
        int xLimit = 1000;
        var entityManager = systemState.EntityManager;
        NativeArray<Entity> clones = entityManager.Instantiate(spawner.Prefab, spawner.Count, Allocator.Temp);
        for (int i = 0; i < clones.Length; i++)
        {
            if(x > xLimit)
            {
                x = 0;
                z += 1.1f;
            }
            float3 pos = new(x, 0, z);

            entityManager.SetComponentData(clones[i], LocalTransform.FromPosition(pos));
            entityManager.AddComponentData(clones[i], new AnchorPos() { Value = new(x, 0, z) });
            x += 1.1f;
        }
        entityManager.AddComponent<SpawnedTag>(spawnerEntity);
        clones.Dispose();
    }
}
