using System.Collections;
using System.Collections.Generic;
using Source.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // TODO (Quick menu) Configuration and saving menu
            SceneManager.LoadScene("MainMenu");
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
