using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Resources;

namespace UI.View
{
    public class RemoveMenuView : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown resourceDropdownList;
        public void Construct()
        {
            List<TMP_Dropdown.OptionData> resourceTypeList = new();
            Resource[] resourceList = (Resource[])Enum.GetValues(typeof(Resource));
            foreach (Resource r in resourceList)
            {
                TMP_Dropdown.OptionData optionData = new()
                {
                    text = r.ToString(),
                };
                resourceTypeList.Add(optionData);
            }
            resourceDropdownList.ClearOptions();
            resourceDropdownList.AddOptions(resourceTypeList);
        }
    }
}