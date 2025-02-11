namespace HotdogSystem.Decorator.DecoratorTypes
{
    public class SweetOnionDecorator : HotdogDecorator
    {
        public SweetOnionDecorator(Hotdog decoratedHotdog, string name = " with sweet onion", int cost = 20, int mass = 10) : base(decoratedHotdog, name, cost, mass)
        {
            this.name = name;
            this.cost = cost;
            this.mass = mass;
            this.decoratedHotdog = decoratedHotdog;
        }
    }
    
}
