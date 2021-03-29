using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public class Inventory
    {
        public List<Item> Content { get; set; }

        public Inventory()
        {
            Debug.Log("Initialized Content in Inventory");
            Content = new List<Item>();
        }
    }
}