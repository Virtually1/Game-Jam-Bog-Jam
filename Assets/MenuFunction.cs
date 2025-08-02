using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunction : MonoBehaviour
{
    public GameObject mainMenu;
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!paused)
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
