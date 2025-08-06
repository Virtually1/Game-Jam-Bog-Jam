using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAI : MonoBehaviour
{
    public GameObject spawnzone;
    public int amount;
    public int limit;
    public float timer;
    public float delay;
    public bool spawned;
    public GameObject[] npc;
    public Transform[] locations;
    public AM AM;
    public int rng;
    public GameObject[] temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = new GameObject[limit];
    }

    // Update is called once per frame
    void Update()
    {
        if(amount<limit&&spawned)
        {

            rng = Random.Range(0,npc.Length);
            temp[amount] = ((GameObject)Instantiate(npc[rng], spawnzone.transform));
            temp[amount].name = "Person - " + amount.ToString();
            //AM.Spawn(amount);
            amount++;
            spawned = false;
            AM.Spawn(amount-1);
        }
        Delay();
    }
    public void Delay()
    {
        if(!spawned&& amount < limit)
        {
            timer += Time.deltaTime;
            if(timer > delay)
            {
                spawned = true;
                timer = 0;
            }
        }
    }
}
