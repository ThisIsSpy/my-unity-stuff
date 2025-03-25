using Events;
using Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResourceResetButton : MonoBehaviour
    {
        [SerializeField] private ObservableSO resetResourceAmountsSO;
        private Button button;
        private ResourcePool resourcePool;

        public void Construct(ResourcePool resourcePool)
        {
            this.resourcePool = resourcePool;
            button = GetComponent<Button>();
            Subscribe();
        }

        private void Subscribe()
        {
            button.onClick.AddListener(ResetResourceCount);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(ResetResourceCount);
        }

        private void ResetResourceCount()
        {
            for(int i = 0; i < resourcePool.ResourceAmounts.Length; i++)
            {
                resourcePool.ResourceAmounts[i] = 0;
            }
            resetResourceAmountsSO.Notify();
        }
    }
}