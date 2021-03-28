using DungeonCrawl.Actors.Items;
using UnityEngine;

namespace Source.Actors.Items
{
    public class InventoryManager
    {
        public Inventory Inventory { get; set; }

        public InventoryManager(Inventory inventory)
        {
            Inventory = inventory;
        }

        public void Display()
        {
            // #TODO connect to Unity interface
            Debug.Log($"Hey I am a {Inventory} ");
        }
    }
}