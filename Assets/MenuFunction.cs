using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunction : MonoBehaviour
{
    public GameObject mainMenu;
    public bool paused = false;
    public bool working=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!paused&&!working)
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
    public void exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
