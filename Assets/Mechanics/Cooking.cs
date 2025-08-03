using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public bool cancook = false;
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cancook)
        {
            Menu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Menu.SetActive(false);
                cancook = false;
            }
        }
    }
    public void Chop()
    {
       Debug.Log("Chopping ingredients...");
    }
}
