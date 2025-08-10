using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{
    public bool cancook = false;
    public GameObject Menu;
    public GameObject chopping;
    public GameObject[] foods;
    public int chopcount=0;
    public bool spawned=false;
    public int rng;
    public int[] order;
    public Interact interact;
    public int c=0;
    public int count;
    public GameObject pot;
    public int[] potid;
    public int[] dishreqid = new int[4];
    public FoodReq[] foodrequirement=new FoodReq[7];
    public int z;
    public int ti;
    public GameObject prefab;
    public int o;
    public Tasks tk;
    public Transform[] Points;
    public GameObject[] temp ;
    public RedirectCooking[] Rc;
    public string tname;
    public bool inpot;
    public Cleaning cl;
    public int v;
    public bool once = false;
    public int dishes;
    // Start is called before the first frame update
    void Start()
    {

      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cancook)
        {
            if(!once)
            {
                once = true;
                Order();
            }
            if (!spawned)
            {
                
                if (c<order.Length&&order[c] != -1 && dishreqid[c]>3)
                {
                    z = dishreqid[c] - 4;
                    order[c] = -1;
                    foods[z].SetActive(true);
                    spawned = true;
                    c++;
                }
                if (c < order.Length&&order[c] != -1 && dishreqid[c]<4)
                {
                    order[c] = -1;
                }
            }
            

            if (Input.GetKey(KeyCode.Escape))
            {
                interact.work = false;
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
            Debug.Log(foods[z].gameObject.name);
            foods[z].SetActive(false);
            chopcount = 0;
            spawned = false;
            count++;
            
        }
        if (count == order.Length)
        {
            Debug.Log("intra");
            SpawnSlice();
            pot.SetActive(true);
            chopping.SetActive(false);
            c = 0;
            z=0;
            count = 0;
            inpot = true;
        }
    }
    public void Order()
    {
        if(gameObject.activeSelf)
        {
            v = 0;
            for (int i = 0; i < foodrequirement[tk.ordersid[tk.currentorder]].ingredientIDRequired.Length; i++)
            {
                if (foodrequirement[tk.ordersid[tk.currentorder]].ingredientIDRequired[i] > 4)
                {
                    ti++;

                }
            }
            dishreqid = new int[ti];
            potid = new int[ti];
            for (int i = 0; i < foodrequirement[tk.ordersid[tk.currentorder]].ingredientIDRequired.Length; i++)
            {
                if (foodrequirement[tk.ordersid[tk.currentorder]].ingredientIDRequired[i] > 4)
                {
                    dishreqid[v] = foodrequirement[tk.ordersid[tk.currentorder]].ingredientIDRequired[i];
                    v++;
                }
            }
            order = new int[ti];
            temp = new GameObject[ti];
            Rc = new RedirectCooking[ti];
        }
        
    }
    public void SpawnSlice()
    {
        ingredients ing = new ingredients();
        for (int i = 0;i<temp.Length; i++)
        {
            tname = Enum.GetName(typeof(ingredients), dishreqid[i]);
            temp[i] = ((GameObject)Instantiate(prefab, Points[i]));
            Rc[i]= temp[i].GetComponent<RedirectCooking>();
            temp[i].name = tname;
            temp[i].GetComponent<RawImage>().color = foods[dishreqid[i]-4].GetComponent<RawImage>().color;
            temp[i].transform.SetParent(Points[i].transform, false);
            temp[i].transform.localPosition = new Vector2(0,0);
            Rc[i].cook = this.GetComponent<Cooking>();
        }
    }
    public void serving()
    {
        if(o==dishreqid.Length&&inpot)
        {
            inpot = false;
            Menu.SetActive(true);
            pot.SetActive(false);
            chopping.SetActive(true );
            tk.nextorder();
            once = false;
            spawned=false;
            ti = 0;
            o = 0;
            dishes++;
            if (tk.currentorder == tk.amount)
            {

                tk.currentorder = 0;
                interact.work = false;
                Menu.SetActive(false);
                cancook = false;
                once = true;
                tk.taskid = 1;
                for(int i=0; i<tk.ordersid.Length; i++)
                    tk.ordersid[i] = 0;
                for (int i = 0; i < order.Length; i++)
                    order[i] = 0;
            }
        }
    }
    public enum ingredients
    {
        BSlice = 4,
        CSlice = 5,
        ChSlice = 6,
        CiSlice = 7,
        FSlice = 8,
        MSlice = 9,
        PSlice = 10,
        TSlice = 11,
        WSlice = 12,
    }
}
