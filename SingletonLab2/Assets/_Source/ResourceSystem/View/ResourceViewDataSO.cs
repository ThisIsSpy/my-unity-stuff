using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ResourceSystem.View
{
    [CreateAssetMenu(fileName = "ResourceDataViewSO",menuName = "SO/New Resource View Data", order = 49)]
    public class ResourceViewDataSO : ScriptableObject
    {
        [field: SerializeField] public List<ResourceViewData> Data { get; private set; }

        public bool TryGetActiveIcon(ResourceType type, out Sprite icon)
        {
            icon = null;
            foreach (ResourceViewData data in Data)
            {
                if(data.Type == type)
                {
                    icon = data.ActiveStateIcon; 
                    return true;
                }
            }
            return false;
        }
        public bool TryGetInactiveIcon(ResourceType type, out Sprite icon)
        {
            icon = null;
            foreach (ResourceViewData data in Data)
            {
                if (data.Type == type)
                {
                    icon = data.InactiveStateIcon;
                    return true;
                }
            }
            return false;
        }
    }
}