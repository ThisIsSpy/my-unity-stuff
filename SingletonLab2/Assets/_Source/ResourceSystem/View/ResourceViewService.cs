using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ResourceSystem;

namespace ResourceSystem.View
{
    public class ResourceViewService
    {
        private static ResourceViewService instance;
        public static ResourceViewService Instance
        {
            get
            {
                instance ??= new ResourceViewService();

                return instance;
            }
        }
        private ResourceViewDataSO _viewData;
        private ResourceViewDataSO ViewData
        {
            get
            {
                if (_viewData == null)
                {
                    _viewData = Resources.Load("ResourceDataViewSO") as ResourceViewDataSO;
                }
                return _viewData;
            }
        }
        public void SetActiveIcon(Image resourceIcon, ResourceType type)
        {
            if (ViewData.TryGetActiveIcon(type, out Sprite icon))
            {
                resourceIcon.sprite = icon;
            }
        }
        public void SetInactiveIcon(Image resourceIcon, ResourceType type)
        {
            if (ViewData.TryGetInactiveIcon(type, out Sprite icon))
            {
                resourceIcon.sprite = icon;
            }
        }
    }
}