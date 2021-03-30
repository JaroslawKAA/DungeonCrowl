using DungeonCrawl;
using DungeonCrawl.Actors.Items;

namespace Source.Actors.Items
{
    public class Armor : Item
    {
        public int Protection { get; set; }

        public Armor(string name,int protection) : base(name)
        {
            Protection = protection;
            this.Type = ItemType.Armor;
        }
  
    }
}