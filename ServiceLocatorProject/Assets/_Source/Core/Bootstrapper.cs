using Panels;
using Panels.Statemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panels.UIStates;
using Services;
using Score;

namespace Core
{
    
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MainPanelView mainPanelView;
        [SerializeField] private SecondPanelView secondPanelView;
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private AudioClip openPanelClip;
        [SerializeField] private AudioClip closePanelClip;
        [SerializeField] private AudioSource audioSource;
        private IStatemachine uiSwitcher;
        private ServiceLocator serviceLocator;
        private FadeService fadeService;
        private SoundPlayer soundPlayer;
        private PlayerPrefsSaver playerPrefsSaver;
        private JSONSaver jsonSaver;

        void Start()
        {
            ServiceSetup();
            UIStatemachineSetup();
        }

        private void ServiceSetup()
        {
            fadeService = new();
            soundPlayer = new(audioSource);
            playerPrefsSaver = new(scoreCounter);
            jsonSaver = new(scoreCounter);
            //serviceLocator = new(fadeService, soundPlayer, playerPrefsSaver, jsonSaver);
        }

        private void UIStatemachineSetup()
        {
            MainPanelController mainPanelController = new(mainPanelView);
            //SecondPanelController secondPanelController = new(secondPanelView, openPanelClip, closePanelClip, serviceLocator);
            //uiSwitcher = new UISwitcher<UIController>(mainPanelController, secondPanelController);
            uiSwitcher.ChangeState<MainPanelController>();
            //mainPanelView.Construct(uiSwitcher);
            //secondPanelView.Construct(uiSwitcher);
        }
    }
    
}
