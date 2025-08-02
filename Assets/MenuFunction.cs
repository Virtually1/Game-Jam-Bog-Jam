using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunction : MonoBehaviour
{
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }

    }
    public void Menu()
    {
        if (mainMenu.activeSelf)
        {
            mainMenu.SetActive(false);
            Time.timeScale = 1f; // Resume the game
        }
        else
        {
            mainMenu.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }
}
