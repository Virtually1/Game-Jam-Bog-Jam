using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public Table[] tables = new Table[8];
    public bool hastaken=false;

    // Start is called before the first frame update
    void Start()
    {
        rb = new Rigidbody2D[na.limit];
        }

    // Update is called once per frame
    void Update()
    {


    }
    public void Spawn(int id)
    {
        idl= id;
        rb[idl] = na.temp[id].GetComponent<Rigidbody2D>();
        Seating(id);
    }
    public void Seating(int id)
    {
        hastaken = false;
        idn = id;
        for(int i = 0; i < na.locations.Length; i++)
        {
            if (!tables[i].taken)
            {
                for(int j = 0; j < tables[i].chairpos.Length; j++)
                {
                    if (tables[i].chairid[j]!=1&&!hastaken)
                    {
                        rb[idn].gameObject.transform.position = tables[i].chairpos[j].transform.position;
                        tables[i].chairstaken++;
                        tables[i].chairid[j] = 1;
                        tables[i].OrderManage();
                        hastaken= true;
                    }
                }

            }
        }
        
        
    }
}
