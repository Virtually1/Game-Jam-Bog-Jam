using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AM : MonoBehaviour
{
    public NpcAI na;
    public float[] xpos;
    public float[] ypos;
    public float speed;
    public Rigidbody2D[] rb;
    public int rng;
    public int idn;
    public int idl;
    public int idr;

    // Start is called before the first frame update
    void Start()
    {
        rb = new Rigidbody2D[na.npc.Length];
        xpos = new float[na.npc.Length];
        ypos = new float[na.npc.Length];

    }

    // Update is called once per frame
    void Update()
    {
        for( idr  = 0; idr < rb.Length;idr++)
        {
            if(rb[idr] != null)
            {
                xpos[idr] = rb[idr].gameObject.transform.position.x;
                ypos[idr] = rb[idr].gameObject.transform.position.y;
            }
          
        }
    }
    public void Spawn(int id)
    {
        idl= id;
        rb[idl] = na.temp[id].GetComponent<Rigidbody2D>();
        //Seating(id);
    }
    public void Seating(int id)
    {

        idn = id;
        rng=Random.Range(0,na.locations.Length);
        while(xpos[idn] > na.locations[rng].position.x)
        {
            rb[idn].velocity = new Vector2(-1 * speed, 0);
        }
        while (xpos[idn] < na.locations[rng].position.x)
        {
            rb[idn].velocity = new Vector2(1 * speed, 0);
        }
        while (ypos[idn] < na.locations[rng].position.y)
        {
            rb[idn].velocity = new Vector2(0 , 1*speed);
        }
    }
}
