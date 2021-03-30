using System;
using System.Collections.Generic;
using System.Linq;
using DungeonCrawl.Actors;
using UnityEngine;

// ReSharper disable All

namespace Source.Core
{
    public class ItemDetector : MonoBehaviour
    {
        public GameObject selector;

        private readonly String[] DETECTABLE_TAGS = new String[]
        {
            "Interactive",
            "Item",
            "Character"
        };

        private List<GameObject> _itemsAround;

        public List<GameObject> ItemsAround
        {
            get => _itemsAround;
            set => _itemsAround = value;
        }

        private GameObject _selectedItem;

        public GameObject SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }

        private void Awake()
        {
            ItemsAround = new List<GameObject>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (DETECTABLE_TAGS.Contains(other.tag))
            {
                ItemsAround.Add(other.gameObject);

                Select();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (DETECTABLE_TAGS.Contains(other.tag))
            {
                RemoveItemFromItemsAround(other.gameObject);

                Select();
            }
        }

        /// <summary>
        /// Remove item from ItemsAround List.
        /// Prevent a situation in which the list contains more than one reference to an object.
        /// </summary>
        /// <param name="obj">Object to remove from ItemsAround List.</param>
        private void RemoveItemFromItemsAround(GameObject obj)
        {
            List<GameObject> result = new List<GameObject>();

            foreach (GameObject o in ItemsAround)
            {
                if (o != obj)
                {
                    result.Add(o);
                }
            }

            ItemsAround = result;
        }

        public void Activate()
        {
            if (SelectedItem != null)
            {
                SelectedItem.GetComponent<ISelectable>().Activate(gameObject);
            }
        }

        /// <summary>
        /// Get closest to player item.
        /// </summary>
        /// <returns>Closest to player item.</returns>
        private GameObject GetClosestItem()
        {
            if (ItemsAround.Count > 0)
            {
                GameObject closestItem = ItemsAround[0];
                float closestDistance = Vector2.Distance(closestItem.transform.position,
                    gameObject.transform.position);
                foreach (var item in ItemsAround)
                {
                    float distance = Vector2.Distance(item.transform.position,
                        gameObject.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestItem = item;
                    }
                }

                return closestItem;
            }

            return null;
        }

        private GameObject SelectorInstance { get; set; }

        /// <summary>
        /// Instantiate selector(UI) above selected item.
        /// </summary>
        private void Select()
        {
            SelectedItem = GetClosestItem();

            if (SelectorInstance != null)
                Destroy(SelectorInstance);

            if (SelectedItem != null)
                SelectorInstance = Instantiate(selector, SelectedItem.transform.position, Quaternion.identity);
        }
    }
}