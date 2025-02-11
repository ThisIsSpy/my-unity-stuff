namespace HotdogSystem
{
    
    public abstract class Hotdog
    {
        protected string name;
        protected int cost;
        protected int mass;

        public Hotdog(string name = "Nexus Hotdog", int cost = 9999, int mass = -1)
        {
            this.name = name;
            this.cost = cost;
            this.mass = mass;
        }

        public virtual string GetName() 
        { 
            return name; 
        }

        public virtual int GetCost()
        {
            return cost;
        }

        public virtual int GetMass()
        {
            return mass;
        }
    }
    
}
