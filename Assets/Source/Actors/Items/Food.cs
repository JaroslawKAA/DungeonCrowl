using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using UnityEngine;

namespace Source.Actors.Items
{
    public class Food : Item
    {
        [SerializeField] private int _healing;
        private int Healing { get; set; }
        
        public Food(string name, int healing) : base(name)
        {
            Healing = healing;
        }

        public override void Use()
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            player.Heal(_healing);
            player.Inventory.Content.Remove(this);

        }
    }
}