using DungeonCrawl;
using DungeonCrawl.Actors.Items;

namespace Source.Actors.Items
{
    public class Weapon : Item
    {
        public int Demages { get; set; }
        
        public Weapon(string name, ItemType type, int value,int demages) : base(name,value)
        {
            Demages = demages;
        }
    }
}