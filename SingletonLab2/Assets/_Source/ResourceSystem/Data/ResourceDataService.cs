using ResourceSystem.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    public class ResourceDataService
    {
        private static ResourceDataService instance;
        public static ResourceDataService Instance
        {
            get
            {
                instance ??= new ResourceDataService();

                return instance;
            }
        }
        private ResourceDataSO _resourceData;
        public ResourceDataSO ResourceData
        {
            get
            {
                if (_resourceData == null)
                {
                    _resourceData = Resources.Load("ResourceDataSO") as ResourceDataSO;
                }
                return _resourceData;
            }
        }
        public float SetActiveTime(ResourceType type)
        {
            if(ResourceData.TryGetActiveTime(type, out float activeTime))
            {
                return activeTime;
            }
            return 0;
        }
        public float SetInactiveTime(ResourceType type)
        {
            if (ResourceData.TryGetInactiveTime(type, out float inactiveTime))
            {
                return inactiveTime;
            }
            return 0;
        }
    }
}