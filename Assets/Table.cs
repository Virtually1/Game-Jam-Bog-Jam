using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Table : MonoBehaviour
{
    public bool taken=false;
    public Transform[] chairpos = new Transform[4];
    public int[] chairid = new int[4];
    public int[] npcs = new int[4];
    public int chairs = 4;
    public int chairstaken=0;
    public int orders = 0;
    public int rng;
    public GameObject recipe;
    public FoodReq[] Fr = new FoodReq[7];
    public bool serving;
    public int tableid;
    public Tasks tk;
    public bool finished;
    public bool eating;
    public float delay;
    public float timer = 0;
    public NpcAI na;
    public AM am;
    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Fr.Length; i++)
        {
            Fr[i] = recipe.GetComponent<FoodReq>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        serving = Physics2D.OverlapCircle(this.transform.position, 1.5f, LayerMask.GetMask("Player"));

        if(chairstaken!=0)
        {
            taken = true;
            na.reset = true;
        }
        
        if(orders>0&&serving&&Input.GetKeyDown(KeyCode.E)&&tk.taskid==0&&!eating)
        {
            
            TaskManager();

        }
        if(serving&&tk.taskid==1&& Input.GetKeyDown(KeyCode.E)&&tk.tableid==this.tableid)
        {
            eating = true ;
            tk.taskid = 0;
        }
        if(eating)
        {
            Delay();
        }
        if(finished)
        {
            tk.taskcompleted = true;
            pm.score += tk.taskpoints;
            tk.taskpoints = 0;
            taken = false;
            FinishedEating();
            na.amount = na.amount - chairstaken;
            chairstaken = 0;
            finished = false;
            tk.j = 0;
        }
    }
    public void FinishedEating()
    {
        for (int i = 0; i < chairstaken; i++)
        {
            if (npcs[i] != -1)
            {
                Destroy(na.temp[npcs[i]]);
                npcs[i] = -1;
            }
            chairid[i] = 0;
        }
        orders = 0;
    }
    public void TaskManager()
    {
        for(int i = 0;i<orders;i++)
        {
            rng = Random.Range(1,7);
            Debug.Log("Task");
            tk.ordersid[i] = rng;
        }
        tk.taskid = 2;
        tk.amount = orders;
        tk.tableid = tableid;
    }
    public void OrderManage()
    {
        orders++;
    }
    public void Delay()
    {
        timer += Time.deltaTime;
        if(timer>delay)
        {
            timer = 0;
            eating=false;
            finished = true;
        }
    }
}

