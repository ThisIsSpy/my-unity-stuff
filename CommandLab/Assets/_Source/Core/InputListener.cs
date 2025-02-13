using CommandSystem;
using CommandSystem.Commands;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode undoKey;
        [SerializeField] private bool isTask3;
        private CommandInvoker invoker;
        private PrefabSpawner.PrefabSpawner prefabSpawner;
        private PlayerMover.PlayerMover playerMover;
        private bool isConstructed = false;

        public void Construct(CommandInvoker invoker, PrefabSpawner.PrefabSpawner prefabSpawner, PlayerMover.PlayerMover playerMover)
        {
            this.invoker = invoker;
            this.prefabSpawner = prefabSpawner;
            this.playerMover = playerMover;
            isConstructed = true;
        }

        private void Update()
        {
            if(isConstructed)
            {
                ListenForPrefabSpawnerInput();
                ListenForPlayerMoverInput();
                ListenForUndoInput();
                ListenForInvokeScheduledCommandsInput();
            }
        }

        private void ListenForPrefabSpawnerInput()
        {
            if (Input.GetMouseButtonDown(1))
            {
                PrefabSpawnerCommand command = new(prefabSpawner, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (!isTask3)
                {
                    invoker.InvokeCommand(command);
                }
                else
                {
                    invoker.AddCommand(command);
                }
            }
        }

        private void ListenForPlayerMoverInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerMoverCommand command = new(playerMover, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (!isTask3)
                {
                    invoker.InvokeCommand(command);
                }
                else
                {
                    invoker.AddCommand(command);
                }
            }
        }

        private void ListenForUndoInput()
        {
            if(Input.GetKeyDown(undoKey))
            {
                invoker.UndoCommand();
            }
        }

        private void ListenForInvokeScheduledCommandsInput()
        {
            if (isTask3 && Input.GetKeyDown(KeyCode.Q))
            {
                invoker.InvokeScheduledCommands();
            }
        }
    }
}
