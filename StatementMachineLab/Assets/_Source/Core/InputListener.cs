using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystem;
using Core;
using PlayerSystem.PlayerState;
using Core.GameStates;

public class InputListener : MonoBehaviour
{
    [SerializeField] private KeyCode shootKey;
    [SerializeField] private KeyCode highlightKey;
    [SerializeField] private KeyCode semiInvisibleKey;
    private PlayerController controller;
    private IStatemachine playerStatemachine;
    private IStatemachine gameStatemachine;
    private bool isEnabled;
    private bool isPaused;
    private bool canBePaused;

    private void Start()
    {
        isPaused = false;
        canBePaused = true;
    }
    private void Update()
    {
        if (isEnabled)
        {
            ListenForMoveInput();
            ListenForShootInput();
            ListenForHighlightInput();
            ListenForSemiInvisibleInput();
            ListenForFinalInput();
        }
        if(canBePaused)
        {
            ListenForPauseInput();
        }
    }
    private void ListenForMoveInput()
    {
        controller.InvokeMove();
    }
    private void ListenForShootInput()
    {
        if(Input.GetKeyDown(shootKey))
        {
            playerStatemachine.ChangeState<ShootingState>();
        }
    }
    private void ListenForHighlightInput()
    {
        if(Input.GetKeyDown(highlightKey))
        {
            playerStatemachine.ChangeState<HighlightState>();
        }
    }
    private void ListenForSemiInvisibleInput()
    {
        if (Input.GetKeyDown(semiInvisibleKey))
        {
            playerStatemachine.ChangeState<SemiInvisibleState>();
        }
    }
    private void ListenForPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isPaused)
            {
                isPaused = false;
                gameStatemachine.ChangeState<GamingState>();
            }
            else
            {
                isPaused = true;
                gameStatemachine.ChangeState<PauseState>();
            }
        }
    }
    private void ListenForFinalInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameStatemachine.ChangeState<FinalState>();
        }
    }
    public void Construct(PlayerController controller, IStatemachine playerStatemachine, IStatemachine gameStatemachine)
    {
        this.controller = controller;
        this.playerStatemachine = playerStatemachine;
        this.gameStatemachine = gameStatemachine;
    }
    public void ToggleControls(bool toggle)
    {
        isEnabled = toggle;
    }
    public void DisablePause()
    {
        canBePaused = false;
    }
}
