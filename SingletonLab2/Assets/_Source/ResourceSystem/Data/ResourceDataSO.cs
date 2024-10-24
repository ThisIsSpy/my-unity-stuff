using ResourceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "ResourceDataSO", menuName = "SO/New Resource Data", order = 50)]
    public class ResourceDataSO : ScriptableObject
    {
        [field: SerializeField] public List<ResourceData> Data { get; private set; }

        public bool TryGetActiveTime(ResourceType type, out float activeTime)
        {
            activeTime = 0f;
            foreach (ResourceData data in Data)
            {
                if (data.Type == type)
                {
                    activeTime = data.ActiveTime;
                    return true;
                }
            }
            return false;
        }
        public bool TryGetInactiveTime(ResourceType type, out float inactiveTime)
        {
            inactiveTime = 0f;
            foreach (ResourceData data in Data)
            {
                if(data.Type == type)
                {
                    inactiveTime = data.InactiveTime;
                    return true;
                }
            }
            return false;
        }
    }
}