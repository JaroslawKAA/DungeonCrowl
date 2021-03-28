using System;
using System.Collections.Generic;
using DungeonCrawl.Actors;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    private List<ISelectable> _itemsAround;

    public List<ISelectable> ItemsAround
    {
        get => _itemsAround;
        set => _itemsAround = value;
    }

    private ISelectable _selectedItem;

    public ISelectable SelectedItem
    {
        get => _selectedItem;
        set => _selectedItem = value;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Object detected: {other.name}");
        // ItemsAround.Add(other.gameObject.GetComponent<ISelectable>());
        var components = other.GetComponents(typeof(ISelectable));
        foreach (var component in components)
        {
            Debug.Log(component);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"Object removed: {other.name}");
        // ItemsAround.Remove(other.gameObject.GetComponent<ISelectable>());
    }
}