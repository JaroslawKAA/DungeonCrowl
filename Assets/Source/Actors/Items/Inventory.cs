using System;
using static System.Console;
using System.Collections.Generic;
using Source.Actors.Items;
using Source.Enums;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public class Inventory
    {
        // TODO Store and manage inventory
        public  List<Item> itemList;
        private ItemType _type;
        private Item _newItem;
        public InventoryManager inventoryManager;
        


        public Inventory()
        {
            itemList = new List<Item>();

        }

        
    }
}