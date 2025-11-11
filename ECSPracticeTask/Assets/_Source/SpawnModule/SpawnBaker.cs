using Unity.Entities;
using UnityEngine;

public class SpawnBaker : Baker<SpawnAuthorization>
{
    public override void Bake(SpawnAuthorization authoring)
    {
        Entity spawner = GetEntity(TransformUsageFlags.None);
        Entity prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic | TransformUsageFlags.Renderable);
        AddComponent(spawner, new Spawner() { Prefab = prefab, Count = authoring.Count });
    }
}