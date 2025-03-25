using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Resources
{
    public class ResourceCard : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private TextMeshProUGUI resourceNameText;
        [SerializeField] private TextMeshProUGUI resourceAmountText;
        public List<ObservableSO> Observables { get; set; }
        public Resource ResourceType { get; private set; }
        private int amount;
        private ResourcePool resourcePool;
        public int Amount { get { return amount; } 
            private set 
            { 
                amount = Mathf.Clamp(value, 0, 999); 
                resourceAmountText.text = amount.ToString();
            } 
        }

        public void Construct(Resource type, List<ObservableSO> observables)
        {
            Amount = 10;
            resourceNameText.text = type.ToString();
            ResourceType = type;
            Observables = observables;
            foreach (ObservableSO observable in Observables)
            {
                observable.RegisterObserver(this);
            }
        }

        public void OnDestroy()
        {
            foreach (ObservableSO observable in Observables)
            {
                observable.RemoveObserver(this);
            }
        }

        public void RegisterResourcePool(ResourcePool resourcePool)
        {
            this.resourcePool = resourcePool;
        }

        public void OnEventHappened()
        {
            Amount = resourcePool.ResourceAmounts[ResourceType.GetHashCode()];
        }
    }
}