using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrefabSpawner
{
    public class PrefabSpawner
    {
        private readonly GameObject prefab;
        private readonly List<GameObject> prefabs;

        public PrefabSpawner(GameObject prefab)
        {
            this.prefab = prefab;
            prefabs = new();
        }

        public void SpawnPrefab(Vector2 position)
        {
            GameObject spawnedPrefab = Object.Instantiate(prefab,position,Quaternion.identity);
            prefabs.Add(spawnedPrefab);
        }

        public void UnspawnPrefab()
        {
            GameObject removedPrefab = prefabs[^1];
            prefabs.Remove(removedPrefab);
            Object.Destroy(removedPrefab);
        }
    }
    
}
