using DungeonCrawl.Actors.Items;

namespace Source.Actors.Items
{
    public class Food : Item
    {
        private int Healing { get; set; }
        
        public Food(string name, int healing) : base(name)
        {
            Healing = healing;
        }
    }
}