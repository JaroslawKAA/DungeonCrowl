using System.Collections.Generic;

namespace DungeonCrawl.Actors.Items
{
    public class Inventory
    {
        // TODO Store and manage inventory
        public  List<Item> itemList;
        private ItemType _type;
        private Item _newItem;


        public Inventory()
        {
            itemList = new List<Item>();

        }

        
    }
}