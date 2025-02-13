using CommandSystem;
using CommandSystem.Commands;
using PlayerMover;
using PrefabSpawner;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject prefab;
        [SerializeField] private InputListener inputListener;

        private PlayerMover.PlayerMover playerMover;
        private PrefabSpawner.PrefabSpawner prefabSpawner;
        private CommandInvoker invoker;

        private void Start()
        {
            playerMover = new(player);
            prefabSpawner = new(prefab);
            invoker = new();

            inputListener.Construct(invoker, prefabSpawner, playerMover);
        }
    }
    
}
