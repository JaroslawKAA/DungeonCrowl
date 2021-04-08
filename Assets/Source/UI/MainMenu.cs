using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject selector;
    private List<GameObject> _options;
    private int _selected = 0;
    private void Awake()
    {
        _options = new List<GameObject>();
        foreach (Transform child in transform)
        {
            _options.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        NavigateMenu();
        UpdateSelectorPosition();
    }

    private void UpdateSelectorPosition()
    {
        selector.transform.position = _options[_selected].transform.position;
    }

    private void NavigateMenu()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            HandleOptions();
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _selected--;
            if (_selected < 0)
            {
                _selected = _options.Count - 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _selected++;
            if (_selected >= _options.Count)
            {
                _selected = 0;
            }
        }
    }

    private void HandleOptions()
    {
        switch (_selected)
        {
            case 0:
                SceneManager.LoadScene("Level1");
                break;
            case 1:
                Application.Quit();
                break;
        }
    }
}
