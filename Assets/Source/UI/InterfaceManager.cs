using System;
using System.Collections;
using System.Collections.Generic;
using Source.Actors.Characters;
using Source.Core;
using Source.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public GameObject QuickMenu;
    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // (Quick menu) Display configuration and saving menu
            QuickMenu.SetActive(!QuickMenu.activeSelf);
            _player.GetComponent<Player>().enabled = !QuickMenu.activeSelf;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryManager.Singleton.Activated)
                InventoryManager.Singleton.DeactivateInventory();
            else
                InventoryManager.Singleton.ActivateInventory();
        }
    }
}