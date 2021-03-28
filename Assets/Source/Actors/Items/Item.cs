using Source.Actors.Items;
using Source.Enums;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Value  {get; set; }

        public Item(string name, int value)
        {
            Name = name;
            Value = value;
            this.Type = ItemType.Other;

        }

        public void PickUp()
        {
            // TODO implement pickup method
            Debug.Log($"Picked up item {ItemType.Armor}");
            Debug.Log($"Picked up item {ItemType.Food} {Value}");
     
        }
    }
}