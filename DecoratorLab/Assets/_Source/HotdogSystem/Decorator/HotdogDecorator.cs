namespace HotdogSystem.Decorator
{
    public class HotdogDecorator : Hotdog
    {
        protected Hotdog decoratedHotdog;

        public HotdogDecorator(Hotdog decoratedHotdog, string name = " with nothing added", int cost = 0, int mass = 0) : base(name, cost, mass)
        {
            this.name = name;
            this.cost = cost;
            this.mass = mass;
            this.decoratedHotdog = decoratedHotdog;
        }

        public override string GetName()
        {
            return decoratedHotdog.GetName() + name;
        }

        public override int GetCost()
        {
            return decoratedHotdog.GetCost() + cost;
        }

        public override int GetMass()
        {
            return decoratedHotdog.GetMass() + mass;
        }
    }
    
}
