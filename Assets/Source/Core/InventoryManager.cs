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
        /// <summary>
        /// Item Prefab to spawn items representations in inventory.
        /// </summary>
        public GameObject UIItemPrefab;

        public static InventoryManager Singleton { get; private set; }

        private Inventory Inventory { get; set; }

        private List<GameObject> InventorySlots { get; set; }
        private GameObject HelmetSlot { get; set; }
        private GameObject ArmorSlot { get; set; }
        private GameObject WeaponSlot { get; set; }
        private GameObject LeftRoll { get; set; }
        private GameObject RightRoll { get; set; }

        /// <summary>
        /// True if we opened inventory, ele false
        /// </summary>
        private bool Activated { get; set; } = false;

        private int SlotsCount { get; set; }


        /// <summary>
        /// Index of selected slot in inventory.
        /// </summary>
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
            LeftRoll = GameObject.Find("LeftRoll");
            RightRoll = GameObject.Find("RightRoll");
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
        /// Refresh inventory view.
        /// </summary>
        public void Display()
        {
            Clear();
            DisplayScrollHints();

            for (int i = 0; i < InventorySlots.Count; i++)
            {
                // Instantiate item icon and set correct image and amount value
                if (i < Inventory.Content.Count)
                {
                    GameObject gameObject = Instantiate(UIItemPrefab, InventorySlots[i].transform);
                    gameObject.GetComponent<Image>().sprite = Inventory.Content[i + _itemsOffset].Sprite;
                    gameObject.GetComponent<RectTransform>().localPosition = new Vector3();
                    gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                        Inventory.Content[i].Amount.ToString();
                }

                InventorySlots[i].GetComponent<RectTransform>().localScale =
                    new Vector3(_slotSize, _slotSize, _slotSize);
            }

            if (Activated)
                SelectSlot();
            else
                DeselectSlot();
        }

        /// <summary>
        /// Display scrolling hints if you have more items than slots.
        /// </summary>
        public void DisplayScrollHints()
        {
            if (_itemsOffset > 0)
                LeftRoll.SetActive(true);
            else
                LeftRoll.SetActive(false);

            if (Inventory.Content.Count > SlotsCount
                && _itemsOffset + SelectedSlot < Inventory.Content.Count - 1)
                RightRoll.SetActive(true);
            else
                RightRoll.SetActive(false);
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


        private int _itemsOffset = 0;

        private void MoveSelectorLeft()
        {
            if (Inventory.Content.Count > 0 && SelectedSlot == 0 && _itemsOffset == 0)
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
            else if (_itemsOffset > 0 && SelectedSlot == 0)
            {
                _itemsOffset--;
            }
            else
            {
                SelectedSlot--;
            }
        }

        private void MoveSelectorRight()
        {
            if (Inventory.Content.Count > 0)
            {
                if (SelectedSlot == SlotsCount - 1
                    && Inventory.Content.Count > SlotsCount
                    && _itemsOffset + SelectedSlot < Inventory.Content.Count - 1)
                {
                    _itemsOffset++;
                }
                else if (SelectedSlot == SlotsCount - 1 || SelectedSlot == Inventory.Content.Count - 1)
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