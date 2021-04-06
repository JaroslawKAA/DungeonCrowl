using DungeonCrawl.Actors.Items;
using DungeonCrawl.Core;
using Source.Actors.Items;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public Inventory Inventory { get; private set; }
        public Equipment Equipment { get; private set; }
        
        [SerializeField] protected int _currentHealth;
        public virtual int CurrentHealth
        {
            get => _currentHealth;
            protected set => _currentHealth = value;
        }
        
        [SerializeField] protected int _maxHealth = 100;
        public virtual int MaxHealth
        {
            get => _maxHealth;
            protected set => _maxHealth = value;
        }
        
        [SerializeField] protected int _attack = 5;
        public virtual int Attack
        {
            get => _attack;
            set => _attack = value;
        }
        
        [SerializeField] protected int _protection = 5;
        public virtual int Protection
        {
            get => _protection;
            set => _protection = value;
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

        public void Heal(int value)
        {
            _currentHealth += value;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            
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
            Equipment = new Equipment();
            _currentHealth = MaxHealth;
        }
    }
}
