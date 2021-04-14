using System.Collections.Generic;
using DungeonCrawl.Actors.Items;
using Source.Actors.Characters;
using Source.Actors.Items;
using UnityEngine;




namespace Source.Core.SavingManager
{
    public class PlayerSaveData
    {
        public Vector3 Position { get; set; }

        public int CurrentHealth { get; set; }

        public int MaxHealth { get; set; }

        public List<Item> Inventory { get; set; }

        public PlayerSaveData(Player player)
        {
            Position = player.Position;
            CurrentHealth = player.CurrentHealth;
            MaxHealth = player.MaxHealth;
            Inventory = player.Inventory.Content;

        }

    }


}