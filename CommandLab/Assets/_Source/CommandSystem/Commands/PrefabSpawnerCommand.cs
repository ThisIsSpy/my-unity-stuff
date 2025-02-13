using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandSystem.Commands
{
    public class PrefabSpawnerCommand : ICommand
    {
        private readonly PrefabSpawner.PrefabSpawner prefabSpawner;

        public Vector3 Position { get; private set; }

        public PrefabSpawnerCommand(PrefabSpawner.PrefabSpawner prefabSpawner, Vector3 position)
        {
            this.prefabSpawner = prefabSpawner;
            Position = position;
        }

        public void Invoke(Vector2 position)
        {
            prefabSpawner.SpawnPrefab(position);
        }

        public void Invoke()
        {
            prefabSpawner.SpawnPrefab(Position);
        }

        public void Undo()
        {
            prefabSpawner.UnspawnPrefab();
        }
    }
    
}
