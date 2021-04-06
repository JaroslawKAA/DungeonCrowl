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
        [SerializeField] private int _protection;

        public int Protection
        {
            get => _protection;
            set => _protection = value;
        }

        public Armor(string name, int protection) : base(name)
        {
            Protection = protection;
            this.Type = ItemType.Armor;
        }

        public override void Use()
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if (player.Equipment.Armor == this)
            {
                player.Equipment.Armor = null;
                player.Protection -= Protection;
            }
            else
            {
                player.Equipment.Armor = this;
                player.Protection += Protection;
            }
        }
    }
}