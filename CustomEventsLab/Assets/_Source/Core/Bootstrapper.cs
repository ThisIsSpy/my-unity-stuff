using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UI.Statemachine;
using UI.UIStates;
using UI.View;
using UnityEngine;

namespace Core 
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private MainMenuView mainMenuPanel;
        [SerializeField] private AddMenuView addMenuPanel;
        [SerializeField] private RemoveMenuView removeMenuPanel;
        [SerializeField] private List<UISwitcherButton> switchers;
        private IStatemachine uiSwitcher;
        private ResourcePool resourcePool;

        void Start()
        {
            StatemachineSetup();
            ViewSetup();
            ResourcePoolSetup();
        }

        private void StatemachineSetup()
        {
            MainMenuController mainMenuController = new(mainMenuPanel);
            AddMenuController addMenuController = new(addMenuPanel);
            RemoveMenuController removeMenuController = new(removeMenuPanel);
            uiSwitcher = new UISwitcher<UIController>(mainMenuController, addMenuController, removeMenuController);
            uiSwitcher.ChangeState<MainMenuController>();
            foreach(var switcher in switchers)
            {
                switcher.Construct(uiSwitcher);
            }
        }

        private void ViewSetup()
        {
            mainMenuPanel.Construct();
            addMenuPanel.Construct();
            removeMenuPanel.Construct();
        }

        private void ResourcePoolSetup()
        {
            List<ResourceCard> resourceCards = mainMenuPanel.GetComponentsInChildren<ResourceCard>().ToList();
            resourcePool = new(resourceCards);
            mainMenuPanel.GetComponentInChildren<ResourceResetButton>().Construct(resourcePool);
            addMenuPanel.GetComponentInChildren<ResourceChangerButton>().Construct(resourcePool);
            removeMenuPanel.GetComponentInChildren<ResourceChangerButton>().Construct(resourcePool);
            foreach (var card in resourceCards)
            {
                card.RegisterResourcePool(resourcePool);
            }
        }
    }
}