using System;
using Source.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class NPC : Character, ISelectable
    {
        // Inspector configuration
        public String message = "Some message...";

        public override string DefaultName { get; } = "NPC_";
        protected override void OnDeath()
        {
            throw new System.NotImplementedException();
        }

        public void Activate(GameObject owner)
        {
            MessageBox.Singleton.DisplayMessage(message);
        }
    }
}