using DungeonCrawl;
using DungeonCrawl.Actors.Items;

namespace Source.Actors.Items
{
    public class Helmet : Item
    {
        public int Protection { get; set; }

        public Helmet(string name, ItemType type, int value,int protection) : base(name, value)
        {
            Protection = protection;
            this.Type = ItemType.Armor;
        }
    }
}