namespace HotdogSystem.HotdogTypes
{
    public class MeatHotdog : Hotdog
    {
        public MeatHotdog(string name = "Meat Hotdog", int cost = 330, int mass = 188) : base(name, cost, mass)
        {
            this.name = name;
            this.cost = cost;
            this.mass = mass;
        }
    }
    
}
