using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Function : MonoBehaviour
{
    public GameObject DifMenu;
    public GameObject Options;
    public GameObject Mmenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Game()
    {
        DifMenu.SetActive(true);
    }
    public void OptionsMenu()
    {
        Options.SetActive(true);    
    }
    public void Menu()
    {
        Options.SetActive(false);
        DifMenu.SetActive(false );
        Mmenu.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
