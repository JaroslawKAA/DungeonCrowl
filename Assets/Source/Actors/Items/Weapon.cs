using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using UnityEngine;

namespace Source.Actors.Items
{
    public class Weapon : Item
    {
        public int Demages { get; set; }

        public Weapon(string name, int demages) : base(name)
        {
            Demages = demages;
        }
        
        public override void Use()
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            player.Equipment.Weapon = this;
            Equip(player.gameObject);
        }
        
        /// <summary>
        /// Display weapon.
        /// </summary>
        /// <param name="player">Player game object</param>
        public void Equip(GameObject player)
        {
            Transform hand = player.transform.GetChild(0);
            foreach (Transform child in hand)
            {
                Destroy(child.gameObject);
            }

            GameObject weapon = CreateWeaponInstance(hand);

            weapon.transform.SetParent(hand, false);
            weapon.transform.localPosition = new Vector3(0.25f, 0.25f, 0f);
        }

        private GameObject CreateWeaponInstance(Transform parent)
        {
            GameObject weaponInstance = new GameObject();
            
            SpriteRenderer sr = weaponInstance.AddComponent<SpriteRenderer>();
            sr.sprite = Sprite;
            sr.sortingOrder = 4;
            
            return weaponInstance;
        }
    }
}