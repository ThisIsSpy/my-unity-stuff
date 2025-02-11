namespace HotdogSystem.HotdogTypes
{
    public class ClassicHotdog : Hotdog
    {
        public ClassicHotdog(string name = "Classic Hotdog", int cost = 210, int mass = 150) : base(name, cost, mass)
        {
            this.name = name;
            this.cost = cost;
            this.mass = mass;
        }
    }
    
}
