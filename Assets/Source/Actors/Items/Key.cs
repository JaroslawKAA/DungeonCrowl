using DungeonCrawl;
using DungeonCrawl.Actors.Items;
using Source.InteractiveItems;
using UnityEngine;

namespace Source.Actors.Items
{
    public class Key : Item

    {
        public Key(string name) : base(name)
        {
        }

        protected override void OnAwake()
        {
            base.OnAwake();
        }
    }
}