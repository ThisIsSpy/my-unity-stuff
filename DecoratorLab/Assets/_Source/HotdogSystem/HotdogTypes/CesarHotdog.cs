namespace HotdogSystem.HotdogTypes
{
    public class CesarHotdog : Hotdog
    {
        public CesarHotdog(string name = "Cesar Hotdog", int cost = 290, int mass = 165) : base(name, cost, mass)
        {
            this.name = name;
            this.cost = cost;
            this.mass = mass;
        }
    }
    
}
