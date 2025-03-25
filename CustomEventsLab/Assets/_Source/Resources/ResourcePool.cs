using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Resources
{
    public class ResourcePool
    {
        public List<ResourceCard> ResourceCards { get; private set; }
        public int[] ResourceAmounts { get; private set; }

        public ResourcePool(List<ResourceCard> resourceCards)
        {
            ResourceCards = resourceCards;
            ResourceAmounts = new int[ResourceCards.Count];
            for (int i = 0;  i < ResourceCards.Count; i++)
            {
                ResourceAmounts[i] = ResourceCards[i].Amount;
            }
        }
    } 
}