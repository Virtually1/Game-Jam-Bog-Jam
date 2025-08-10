using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Cleaning : MonoBehaviour
{
    public bool canclean;
    public int dishamount;
    public GameObject UI;
    public Interact interact;
    public int count;
    public Vector2 v2fab;
    public bool once;
    public GameObject[] temp=new GameObject[5];
    public GameObject prefab;
    public GameObject parent;
    public float rngx;
    public float rngy;
    public RedirectCleaning Rc;
    public int i;
    public Tasks tk;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canclean)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                interact.work = false;
                UI.SetActive(false);
                canclean = false;
            }
            if (dishamount > 0 && !once)
            {
                once = true;
                DirtSpawn();
            }
            if(dishamount ==0)
            {
                tk.taskid = 0;
                interact.work = false;
                UI.SetActive(false);
                canclean = false;
            }
        }
    }
    public void clean()
    {
        if (count == 5)
        {
            dishamount--;
            once = false;
            count = 0;
            i= 0;
        }
    }
    public void DirtSpawn()
    {
        while (i < 5)
        {


            rngx = Random.RandomRange(-90f, 90f);
            rngy = Random.RandomRange(-90f, 90f);
            temp[i] = Instantiate(prefab, parent.transform);
            temp[i].transform.localPosition = new Vector2(rngx, rngy);
            temp[i].name = "Dish" +i.ToString();
            Rc = temp[i].GetComponent<RedirectCleaning>();
            Rc.cl = this.GetComponent<Cleaning>();
            i++;
        }

    }    

}
