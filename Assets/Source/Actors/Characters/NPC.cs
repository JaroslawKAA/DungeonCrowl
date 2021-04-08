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

        private AudioSource _audioSource;
        protected override void OnDeath()
        {
            throw new System.NotImplementedException();
        }

        public void Activate(GameObject owner)
        {
            MessageBox.Singleton.DisplayMessage(message);
            _audioSource.Play();
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            _audioSource = GetComponent<AudioSource>();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}