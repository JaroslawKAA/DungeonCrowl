using System;
using UnityEngine;
using DungeonCrawl.Actors.Characters;
using Source.Actors.Items;
using Source.Core;

// ReSharper disable All

namespace DungeonCrawl.Actors.Items
{
    public class Item : MonoBehaviour, ISelectable
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Value { get; set; }

        public Sprite Sprite { get; private set; }

        public Item(string name, int value)
        {
            Name = name;
            Value = value;
            this.Type = ItemType.Other;
        }

        private void Awake()
        {
            this.Sprite = GetComponent<SpriteRenderer>().sprite;
        }

        public void PickUp(GameObject owner)
        {
            owner.GetComponent<Character>().Inventory.Content.Add(this);
            Destroy(this.gameObject);

            InventoryManager.Singleton.Display();
            MessageBox.Singleton.DisplayMessage("I picked up item! :)");
        }

        public void Activate(GameObject owner)
        {
            PickUp(owner);
        }
    }
}