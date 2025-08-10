using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

public class NpcAI : MonoBehaviour
{
    public GameObject spawnzone;
    public GameObject[] leaving= new GameObject[4];
    public int amount;
    public int limit;
    public float timer;
    public float delay;
    public bool spawned;
    public GameObject[] npc;
    public Transform[] locations;
    public AM AM;
    public int rng;
    public int pack;
    public float chance;
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
            pack = Random.Range(1,5);
            if(pack ==1)
            {
                chance=Random.Range(0f,1f);
                if(chance >0.6)
                {
                    pack++;
                }
                if(chance >0.9)
                {
                    pack++;
                }
            }
            if (pack > limit - amount)
                pack = limit - amount;
            for(int i = 0; i <pack; i++)
            {
                rng = Random.Range(0, npc.Length);
                temp[amount] = ((GameObject)Instantiate(npc[rng], spawnzone.transform));
                temp[amount].name = "Person - " + amount.ToString();
                amount++;
                spawned = false;
                AM.Spawn(amount - 1);
            }    
            
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
