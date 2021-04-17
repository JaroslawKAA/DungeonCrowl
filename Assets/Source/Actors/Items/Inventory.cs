using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Actors.Items;

namespace Source.Actors.Items
{
    public class Inventory
    {
        private List<Item> _content;

        public int Count => _content.Count;

        public Inventory()
        {
            _content = new List<Item>();
        }

        public bool HaveItem(string id)
        {
            return _content.First(item => item.Id == id) != null;
        }

        public void RemoveItem(string id)
        {
            _content.Remove(GetItem(id));
        }
        
        public void RemoveItem(Item item)
        {
            _content.Remove(item);
        }

        public Item GetItem(string id)
        {
            return _content.First(i => i.Id == id);
        }

        public Item GetItem(int index)
        {
            return _content[index];
        }

        public void AddItem(Item item)
        {
            _content.Add(item);
        }

        public List<Item> GetItems()
        {
            return _content;
        }
    }
}