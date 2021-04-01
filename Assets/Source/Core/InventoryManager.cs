using System;
using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Core
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
        private bool Activated { get; set; } = false;
        private int SlotsCount { get; set; }

        private int SelectedSlot { get; set; } = 0;
        public float _slotSize;
        public float _selectedSlotSize = 1;
        private GameObject _player;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }

            Singleton = this;


            HelmetSlot = GameObject.FindWithTag("HelmetSlot");
            ArmorSlot = GameObject.FindWithTag("ArmorSlot");
            WeaponSlot = GameObject.FindWithTag("WeaponSlot");
            InventorySlots = new List<GameObject>();

            foreach (Transform child in GameObject.FindWithTag("InventorySlots").transform)
            {
                InventorySlots.Add(child.gameObject);
            }

            SlotsCount = InventorySlots.Count;

            _slotSize = InventorySlots[0].GetComponent<RectTransform>().localScale.x;
            _player = GameObject.FindWithTag("Player");
        }

        private void Start()
        {
            Inventory = _player.GetComponent<Player>().Inventory;

            Display();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (Activated)
                    DeactivateInventory();
                else
                    ActivateInventory();
            }

            if (Activated)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    MoveSelectorLeft();
                    Display();
                }
                else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    MoveSelectorRight();
                    Display();
                }
                else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
                {
                    
                    Inventory.Content[SelectedSlot].Use();
                    Display();
                }
                
            }
        }
        /// <summary>
        /// Refresh inventory state
        /// </summary>
        public void Display()
        {
            Clear();

            for (int i = 0; i < Inventory.Content.Count && i < InventorySlots.Count; i++)
            {
                // Instantiate item icon and set correct image and amount value
                GameObject gameObject = Instantiate(UIItemPrefab, InventorySlots[i].transform);
                gameObject.GetComponent<Image>().sprite = Inventory.Content[i].Sprite;
                gameObject.GetComponent<RectTransform>().localPosition = new Vector3();
                InventorySlots[i].GetComponent<RectTransform>().localScale =
                    new Vector3(_slotSize, _slotSize, _slotSize);
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    Inventory.Content[i].Amount.ToString();
            }

            if (Activated)
                SelectSlot();
            else
                DeselectSlot();
        }
        
        public void ActivateInventory()
        {
            Activated = true;
            _player.GetComponent<Player>().enabled = false;
            Display();
        }

        public void DeactivateInventory()
        {
            Activated = false;
            _player.GetComponent<Player>().enabled = true;
            Display();
        }
        
        /// <summary>
        /// Remove all icons from every slots.
        /// </summary>
        private void Clear()
        {
            foreach (var slot in InventorySlots)
            {
                foreach (Transform child in slot.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        private void MoveSelectorLeft()
        {
            if (Inventory.Content.Count > 0)
            {
                if (SelectedSlot == 0)
                {
                    if (Inventory.Content.Count < SlotsCount)
                    {
                        SelectedSlot = Inventory.Content.Count - 1;
                    }
                    else
                    {
                        SelectedSlot = SlotsCount - 1;
                    }
                }
                else
                {
                    SelectedSlot--;
                }
            }
        }

        private void MoveSelectorRight()
        {
            if (Inventory.Content.Count > 0)
            {
                if (SelectedSlot == SlotsCount - 1 || SelectedSlot == Inventory.Content.Count - 1)
                {
                    SelectedSlot = 0;
                }
                else
                {
                    SelectedSlot++;
                }
            }
        }

        private void SelectSlot()
        {
            InventorySlots[SelectedSlot].transform.localScale = new Vector3(_selectedSlotSize,
                _selectedSlotSize,
                _selectedSlotSize);
        }

        private void DeselectSlot()
        {
            InventorySlots[SelectedSlot].GetComponent<RectTransform>().localScale = new Vector3(_slotSize,
                _slotSize,
                _slotSize);
        }
    }
}