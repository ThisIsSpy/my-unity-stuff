using Events;
using Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject resourceCollection;
        [SerializeField] private ObservableSO changeResourceObservable;
        [SerializeField] private ObservableSO resetResourceObservable;

        public void Construct()
        {
            Resource[] resourceList = (Resource[])Enum.GetValues(typeof(Resource));
            List<ObservableSO> listSO = new()
            {
                changeResourceObservable,
                resetResourceObservable
            };
            foreach (var item in resourceList)
            {
                GameObject instantiatedPrefab = Instantiate(prefab, resourceCollection.transform);
                instantiatedPrefab.GetComponent<ResourceCard>().Construct(item, listSO);
            }
        }
    }
}