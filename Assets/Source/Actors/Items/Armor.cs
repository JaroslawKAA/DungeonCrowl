using System;
using DungeonCrawl;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using Source.Core;
using UnityEngine;

namespace Source.Actors.Items
{
    public class Armor : Item
    {
        public int Protection { get; set; }

        public Armor(string name, int protection) : base(name)
        {
            Protection = protection;
            this.Type = ItemType.Armor;
        }

        public override void Use()
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            player.Equipment.Armor = player.Equipment.Armor == this ? null : this;
        }
    }
}