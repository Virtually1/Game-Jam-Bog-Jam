
using TMPro;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public int taskid;
    public int tableid;
    public int amount;
    public string taskname;
    public bool hastask;
    public bool finished;
    public int[] ordersid = new int[4];
    public int currentorder = 0;
    public FoodReq[] fr = new FoodReq[7];
    public string tempname;
    public int j=0;
    public Cleaning cl;
    public bool empty=true;
    public TextMeshProUGUI[] orderstext;
    public bool taskcompleted;
    public Timer timer;
    public int difficultyincrement;
    public int dificulty;
    public int taskpoints;
    // Start is called before the first frame update
    void Start()
    {
        dificulty = 3 + StaticData.difficulty;
        difficultyincrement = 15 + (StaticData.difficulty * 5);
        
    }

    // Update is called once per frame
    void Update()
    { 
        text();
        if(cl.dishamount>10&&taskid!=3)
        {
            taskid = 3;
        }
        if(taskcompleted==true)
        {
            taskcompleted = false;
            timer.timeLeft += difficultyincrement;
        }
    }
    public void nextorder()
    {
        currentorder = currentorder + 1;
    }
    public void text()
    {

            if(taskid==2)
            {


                while (j<ordersid.Length)
                {
                    if(ordersid[j]!=0)
                    {


                        orderstext[j].text ="Cook:" + fr[ordersid[j]].names;
                        Debug.Log("intra?");
                    }
                    if (ordersid[j]==0)
                    {
                        orderstext[j].text = "";
                    }
                    j++;
                }
            }
            if(taskid==3)
            {
            orderstext[1].text = "Clean Dishes";
            }
            
            if(taskid!=3&&taskid!=2)
            {
            for(int i=0;i<ordersid.Length;i++)
            {
                orderstext[i].text = "";
            }
            }


        }
}
