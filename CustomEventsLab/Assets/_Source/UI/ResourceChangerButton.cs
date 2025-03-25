using Events;
using Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResourceChangerButton : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown resourceDropdown;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private bool isRemoveButton;
        [SerializeField] private ObservableSO changeResourceAmountSO;
        private ResourcePool resourcePool;
        private Button button;

        public void Construct(ResourcePool resourcePool)
        {
            this.resourcePool = resourcePool;
            button = GetComponent<Button>();
            Subscribe();
        }

        private void Subscribe()
        {
            button.onClick.AddListener(ChangeResourceAmount);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(ChangeResourceAmount);
        }

        public void ChangeResourceAmount()
        {
            if (inputField.text == String.Empty) return;
            int amount = Convert.ToInt32(inputField.text);
            Resource selectedType = (Resource)resourceDropdown.value;
            ResourceCard selectedResource = resourcePool.ResourceCards.Find(selectedResource => selectedResource.ResourceType == selectedType);
            if (selectedResource == null) return;
            if(isRemoveButton) resourcePool.ResourceAmounts[selectedType.GetHashCode()] -= amount;
            else resourcePool.ResourceAmounts[selectedType.GetHashCode()] += amount;
            changeResourceAmountSO.Notify();
        }
    }
}