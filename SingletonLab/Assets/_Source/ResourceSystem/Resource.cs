using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public int ResourceAmount { get; private set; }
    public ResourceType Type { get; private set; }
    public static event System.Action<ResourceType> ResourceChange;
    public Resource(int startValue, ResourceType type)
    {
        ResourceAmount = startValue;
        Type = type;
    }

    public void AddResource(int value)
    {
        ResourceAmount += value;
        if(value != 0)
        {
            ResourceChange?.Invoke(Type);
        }
    }
}
