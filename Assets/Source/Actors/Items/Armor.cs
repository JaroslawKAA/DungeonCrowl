using DungeonCrawl.Actors.Items;
using Source.Enums;

namespace Source.Actors.Items
{
    public class Armor : Item
    {
        public int Protection { get; set; }

        public Armor(string name, ItemType type, int value,int protection) : base(name, value)
        {
            Protection = protection;
            this.Type = ItemType.Armor;
        }
  
    }
}