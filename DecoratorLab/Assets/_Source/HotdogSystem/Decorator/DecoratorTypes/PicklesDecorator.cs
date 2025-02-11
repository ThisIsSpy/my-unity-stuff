using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotdogSystem.Decorator.DecoratorTypes
{
    public class PicklesDecorator : HotdogDecorator
    {
        public PicklesDecorator(Hotdog decoratedHotdog, string name = " with pickles", int cost = 10, int mass = 20) : base(decoratedHotdog, name, cost, mass)
        {
            this.name = name;
            this.cost = cost;
            this.mass = mass;
            this.decoratedHotdog = decoratedHotdog;
        }
    }
    
}
