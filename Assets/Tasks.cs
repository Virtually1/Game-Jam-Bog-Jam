using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public int taskid;
    public int tableid;
    public string[] tasktext;
    public int amount;
    public string taskname;
    public bool hastask;
    public bool finished;
    public int[] ordersid = new int[4];
    public int currentorder = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextorder()
    {
        currentorder = currentorder + 1;
    }
}
