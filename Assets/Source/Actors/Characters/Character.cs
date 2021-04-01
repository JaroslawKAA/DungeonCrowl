using DungeonCrawl.Actors.Items;
using DungeonCrawl.Core;
using Source.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public Inventory Inventory { get; set; }
        
        [SerializeField] private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            private set => _currentHealth = value;
        }
        
        [SerializeField] private int _maxHealth = 100;
        public int MaxHealth
        {
            get => _maxHealth;
            private set => _maxHealth = value;
        }
        
        [SerializeField] private int _attack = 5;
        public int Attack
        {
            get => _attack;
            private set => _attack = value;
        }
        
        [SerializeField] private int _protection = 5;
        public int Protection
        {
            get => _protection;
            private set => _protection = value;
        }
        
        public void ApplyDamage(int damage)
        {
            MaxHealth -= damage;

            if (MaxHealth <= 0)
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
            _currentHealth = MaxHealth;
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}
