using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public int sheetrng;
    public float chance;
    public GameObject[] temp;
    public Sprite[] sprites = new Sprite[8];
    public int direction;
    public bool reset =false;
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
           if(reset==true)
            {
                reset = false;
                direction = 0;
            }
            for(int i = 0; i <pack; i++)
            {
                sheetrng = Random.Range(0, 2);
                rng = Random.Range(0, npc.Length);
                temp[amount] = ((GameObject)Instantiate(npc[rng], spawnzone.transform));
                temp[amount].name = "Person - " + amount.ToString();
                temp[amount].GetComponent<SpriteRenderer>().sprite = sprites[sheetrng*4+(direction%4)];
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
