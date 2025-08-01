using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Delay();
    }
    public void Delay()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0)
        {
           End();
        }

    }
    public void End()
    {
        
        Debug.Log("Time's up!");
    }
}
