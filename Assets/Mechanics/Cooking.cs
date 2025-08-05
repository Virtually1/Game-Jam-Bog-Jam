using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int[] potid= new int[4];
    public int[] dishreqid = new int[4];
    public FoodReq foodrequirement;
    public int z;
    public int ti;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < foodrequirement.ingredientIDRequired.Length; i++)
        {
            if (foodrequirement.ingredientIDRequired[i] > 4)
            {
                ti++;

            }
        }
        dishreqid = new int[ti];
      for (int i = 0; i < foodrequirement.ingredientIDRequired.Length; i++)
        {
            if(foodrequirement.ingredientIDRequired[i]>4)
            {
                dishreqid[i] = foodrequirement.ingredientIDRequired[i];
            }
        }
        order = new int[ti];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cancook)
        {
            if(!spawned)
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
            

            Menu.SetActive(true);
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
            pot.SetActive(true);
            chopping.SetActive(false);
        }
    }
    public enum ingredients
    {
        Tomato,
        Carrots,
        Cheeze,
        Lettuce
    }
}
