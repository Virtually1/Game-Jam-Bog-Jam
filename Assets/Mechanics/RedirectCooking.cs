using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectCooking : MonoBehaviour
{
    public Cooking cook;
    public int c;
    public bool active=false;
    public string zname;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pot()
    {
         ingredients ing = new ingredients();
        for(int i = 0; i <9 ; i++)
        {

            ing = (ingredients)i;
            zname = Enum.GetName(typeof(ingredients), i+4);
            if (this.gameObject.name == zname && cook.o < cook.potid.Length)
            {

                if ((cook.potid[cook.o] = i + 4) == cook.dishreqid[cook.o])
                {
                    cook.potid[cook.o] = i + 4;
                    cook.o++;
                    Debug.Log(name);
                    this.gameObject.SetActive(false);
                    cook.serving();
                }
                else
                {
                    Debug.Log("NOT IN ORDER");
                }
            }

        }

    }    
    public enum ingredients
    {
        BSlice=4,
        CSlice=5,
        ChSlice=6,
        CiSlice=7,
        FSlice=8,
        MSlice=9,
        PSlice=10,
        TSlice=11,
        WSlice=12,
    }
}
