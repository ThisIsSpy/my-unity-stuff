using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using PlayerSystem;
using PlayerSystem.PlayerState;
using Core.GameStates;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Object playerPrefab;
        [SerializeField] private Object bulletPrefab;
        [SerializeField] private TextMeshProUGUI stateText;
        [SerializeField] private TextMeshProUGUI gameStateText;
        [SerializeField] private float moveSpeed;
        private IStatemachine playerStatemachine;
        private IStatemachine gameStatemachine;
        private PlayerModel model;
        private PlayerView view;
        private PlayerController controller;

        private void Start()
        {
            model = new(moveSpeed);
            Object player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            view = player.GetComponent<PlayerView>();
            controller = player.GetComponent<PlayerController>();
            view.Construct(player.GetComponent<Rigidbody2D>());
            controller.Construct(view, model);
            Transform firePos = player.GetComponentInChildren<Transform>().Find("Firepoint");
            SpriteRenderer circle = player.GameObject().transform.GetChild(0).GetComponent<SpriteRenderer>();
            SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
            ShootingState shootingState = new(bulletPrefab, firePos);
            PlayerSystem.PlayerState.HighlightState highlightState = new(circle);
            SemiInvisibleState semiInvisibleState = new(playerSprite);
            playerStatemachine = new PlayerStatemachine<GameState>(shootingState, highlightState, semiInvisibleState, stateText);
            GamingState gamingState = new(inputListener);
            PauseState pauseState = new();
            FinalState finalState = new(playerSprite,inputListener);
            gameStatemachine = new GameStatemachine<GameState>(gamingState,pauseState,finalState,gameStateText);
            inputListener.Construct(controller, playerStatemachine, gameStatemachine);
            gameStatemachine.ChangeState<GamingState>();
        }
        private void Update()
        {
            playerStatemachine.Update();
            gameStatemachine.Update();
        }
    }
}