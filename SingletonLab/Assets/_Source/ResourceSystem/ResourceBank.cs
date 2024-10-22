using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBank
{
    private const int _startResourceValue = 0;
    private Dictionary<ResourceType, Resource> _resources;
    private static ResourceBank instance = null;

    public Dictionary<ResourceType, Resource> Resources { get { return _resources; } }
    public static ResourceBank Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ResourceBank();
            }
            return instance;
        }
    }

    public ResourceBank()
    {
        InitResource();
    }
    private void InitResource()
    {
        _resources = new();

        for(int i = 0; i < Enum.GetValues(typeof(ResourceType)).Length; i++)
        {
            Resource newResource = new(_startResourceValue,(ResourceType)i);
            _resources.Add((ResourceType)i, newResource);
        }
    }
    public bool TryGetResourceAmount(ResourceType type, out int resourceAmount)
    {
        resourceAmount = 0;
        if (_resources.ContainsKey(type))
        {
            resourceAmount = _resources[type].ResourceAmount;
            return true;
        }
        return false;
    }
    public void AddResourceAmount(ResourceType type, int resourceAmount)
    {
        _resources[type].AddResource(resourceAmount);
    }
}
