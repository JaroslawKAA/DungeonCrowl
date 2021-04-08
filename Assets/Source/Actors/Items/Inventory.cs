using System.Collections.Generic;
using DungeonCrawl.Actors.Items;

namespace Source.Actors.Items
{
    public class Inventory
    {
        public List<Item> Content { get; set; }

        public Inventory()
        {
            Content = new List<Item>();
        }
    }
}