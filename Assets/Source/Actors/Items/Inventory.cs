using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
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