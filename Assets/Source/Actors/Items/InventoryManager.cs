using System;
using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Actors.Items
{
    public class InventoryManager : MonoBehaviour
    {
        public GameObject UIItemPrefab;
        
        public static InventoryManager Singleton { get; private set; }
        
        private Inventory Inventory { get; set; }

        private List<GameObject> InventorySlots { get; set; }
        private GameObject HelmetSlot { get; set; }
        private GameObject ArmorSlot { get; set; }
        private GameObject WeaponSlot { get; set; }

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;
            
            Inventory = GameObject.FindWithTag("Player").GetComponent<Player>().Inventory;
            HelmetSlot = GameObject.FindWithTag("HelmetSlot");
            ArmorSlot = GameObject.FindWithTag("ArmorSlot");
            WeaponSlot = GameObject.FindWithTag("WeaponSlot");
            InventorySlots = new List<GameObject>();
            
            foreach (Transform child in GameObject.FindWithTag("InventorySlots").transform)
            {
                InventorySlots.Add(child.gameObject);
            }
        }

        private void Start()
        {
            Display();
        }

        public void Display()
        {
            Debug.Log(GameObject.FindWithTag("Player").GetComponent<Player>().Inventory.Content.Count);
            for (int i = 0; i < GameObject.FindWithTag("Player").GetComponent<Player>().Inventory.Content.Count; i++)
            {
                GameObject gameObject = Instantiate(UIItemPrefab, InventorySlots[i].transform);
                gameObject.GetComponent<Image>().sprite = GameObject.FindWithTag("Player").GetComponent<Player>().Inventory.Content[i].Sprite;
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3();
            }
        }
    }
}