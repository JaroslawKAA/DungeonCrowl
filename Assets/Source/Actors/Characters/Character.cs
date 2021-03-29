using DungeonCrawl.Actors.Items;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public Inventory Inventory { get; set; }
        
        [SerializeField] private int _health = 100;
        public int Health
        {
            get => _health;
            private set => _health = value;
        }
        
        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;

        protected override void OnAwake()
        {
            base.OnAwake();
            Inventory = new Inventory();
        }
    }
}
