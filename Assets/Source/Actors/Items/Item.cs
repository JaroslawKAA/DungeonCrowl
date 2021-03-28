using UnityEngine;
using DungeonCrawl.Actors.Characters;
// ReSharper disable All

namespace DungeonCrawl.Actors.Items
{
    public class Item : MonoBehaviour, ISelectable
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Value { get; set; }

        public Item(string name, int value)
        {
            Name = name;
            Value = value;
            this.Type = ItemType.Other;
        }

        public void PickUp(GameObject owner)
        {
            owner.GetComponent<Character>().Inventory.Content.Add(this);
            Destroy(this.gameObject);

            Debug.Log(owner.GetComponent<Character>().Inventory.Content);
            Debug.Log(owner.GetComponent<Character>().Inventory.Content.Count);
        }

        public void Activate(GameObject owner)
        {
            PickUp(owner);
        }
    }
}