using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Table : MonoBehaviour
{
    public bool taken=false;
    public Transform[] chairpos = new Transform[4];
    public int[] chairid = new int[4];
    public int chairs = 4;
    public int chairstaken=0;
    public int orders = 0;
    public int rng;
    public GameObject recipe;
    public FoodReq[] Fr = new FoodReq[7];
    public bool serving;
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
        serving = Physics2D.OverlapCircle(this.transform.position, 4f, LayerMask.GetMask("Player"));

        if(chairstaken==chairs)
        {
            taken = true;
        }
        
        if(orders>0&&serving&&Input.GetKeyDown(KeyCode.E))
        {
            TaskManager();
        }
        
    }
    public void TaskManager()
    {
        for(int i = 0;i<orders;i++)
        {
            rng = Random.Range(1,7);

        }
    }
    public void OrderManage()
    {
        orders++;
    }
}

