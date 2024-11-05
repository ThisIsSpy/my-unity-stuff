using PlayerSystem;
using PlayerSystem.PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Object playerPrefab;
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private int maxHp;
        [SerializeField] private int speed;
        [SerializeField] private InputListener inputListener;
        private PlayerModel playerModel;
        private PlayerMovementModel playerMovementModel;

        private void Start()
        {
            playerModel = new(maxHp);
            playerMovementModel = new(speed);
            Object player = Instantiate(playerPrefab, new Vector3(0, 0), new Quaternion(0,0,0,0));
            PlayerView playerView = player.GetComponent<PlayerView>();
            PlayerController playerController = player.GetComponent<PlayerController>();
            PlayerMovementController playerMovementController = player.GetComponent<PlayerMovementController>();
            CollisionDetector collisionDetector = player.GetComponent<CollisionDetector>();
            collisionDetector.player = playerModel;
            playerMovementController.rb = player.GetComponent<Rigidbody2D>();
            playerMovementController.model = playerMovementModel;
            playerMovementController.view = player.GetComponent<PlayerMovementView>();
            playerController.playerView = playerView;
            playerView.PlayerModel = playerModel;
            playerView.HPText = hpText;
            playerView.BootstrapAwake();
            playerController.BootstrapAwake();
            inputListener.SetController(player.GetComponent<PlayerMovementController>());
        }
    }
}
