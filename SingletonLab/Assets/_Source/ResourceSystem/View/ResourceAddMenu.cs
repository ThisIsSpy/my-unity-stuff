using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceAddMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI woodDisplay;
    [SerializeField] private TextMeshProUGUI stoneDisplay;
    [SerializeField] private TextMeshProUGUI diamondDisplay;
    [SerializeField] private TextMeshProUGUI goldDisplay;
    private void Awake()
    {
        FillResourceList();
        Resource.ResourceChange += OnValueChanged;
    }
    private void FillResourceList()
    {
        dropdown.ClearOptions();
        List<string> options = new();
        var resourceList = ResourceBank.Instance.Resources;
        for(int i = 0;i<resourceList.Count;i++)
        {
            options.Add(resourceList[(ResourceType)i].Type.ToString());
        }
        dropdown.AddOptions(options);
    }
    public void OnClickAddButton()
    {
        int index = dropdown.value;
        int resourceAmount = int.Parse(inputField.text);
        ResourceType type = (ResourceType)index;
        ResourceBank.Instance.AddResourceAmount(type, resourceAmount);
    }
    public void OnValueChanged(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Wood:
                {
                    woodDisplay.text = $"Wood: {ResourceBank.Instance.Resources[type].ResourceAmount}";
                    break;
                }
            case ResourceType.Stone:
                {
                    stoneDisplay.text = $"Stone: {ResourceBank.Instance.Resources[type].ResourceAmount}";
                    break;
                }
            case ResourceType.Diamond:
                {
                    diamondDisplay.text = $"Diamond: {ResourceBank.Instance.Resources[type].ResourceAmount}";
                    break;
                }
            case ResourceType.Gold:
                {
                    goldDisplay.text = $"Gold: {ResourceBank.Instance.Resources[type].ResourceAmount}";
                    break;
                }
        }
    }
}
