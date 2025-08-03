using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool caninteract = false;
    public PlayerMovement pm;
    public Cooking ck;
    public MenuFunction menu;
    public GameObject[] Stations;
    public bool work;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        caninteract = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Station"));
        if (caninteract && pm.energy > 10&&!menu.paused)
        {
            Collider2D station = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Station"));
            if(station.gameObject.tag=="Cooking" && Input.GetKeyDown(KeyCode.E))
            {
                 ck.cancook= true;
                menu.working= true;
                work = true;
                pm.energy -= 10; 
            }
        }
        if (work == false)
        {
            menu.working = false;
        }
    }
}
