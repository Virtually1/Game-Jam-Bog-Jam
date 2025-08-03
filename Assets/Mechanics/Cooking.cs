using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public bool cancook = false;
    public GameObject Menu;
    public GameObject[] foods;
    public int chopcount=0;
    public bool spawned=false;
    public int rng;
    public int[] order;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cancook)
        {
            if(!spawned)
            {
                rng = Random.Range(0, 2);
                if(order[rng] != -1 )
                {
                    order[rng] = -1;
                    foods[rng].SetActive(true);
                    spawned = true;
                }
            }
            

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
        
       chopcount++;
       Debug.Log("Chopping ingredients...");
        if(chopcount==5)
        {
            Debug.Log(foods[rng].gameObject.name);
            foods[rng].SetActive(false);
            chopcount = 0;
            spawned = false;
        }
    }
}
