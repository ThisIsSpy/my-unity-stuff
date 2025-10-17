using Unity.Entities;
using UnityEngine;

public class SpawnAuthorization : MonoBehaviour
{
    public GameObject Prefab;
    public int Count;
}

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public int Count;
}

public class SpawnBaker : Baker<SpawnAuthorization>
{
    public override void Bake(SpawnAuthorization authoring)
    {
        Entity spawner = GetEntity(TransformUsageFlags.None);
        Entity prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic | TransformUsageFlags.Renderable);
        AddComponent(spawner, new Spawner() { Prefab = prefab, Count = authoring.Count });
    }
}
