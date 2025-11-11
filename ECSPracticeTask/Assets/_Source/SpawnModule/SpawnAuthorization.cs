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
