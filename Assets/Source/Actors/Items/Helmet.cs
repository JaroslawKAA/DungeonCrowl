using DungeonCrawl;
using DungeonCrawl.Actors.Items;

namespace Source.Actors.Items
{
    public class Helmet : Armor
    {

        public Helmet(string name,int protection) : base(name, protection)
        {
            this.Type = ItemType.Armor;
        }
    }
}