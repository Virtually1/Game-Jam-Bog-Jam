using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 120f;
    public TextMeshProUGUI timertext;
    public float vtimeleft;
    public float minutes;
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
            vtimeleft = timeLeft- (int)timeLeft;
            vtimeleft = vtimeleft * 100;
            if (timeLeft > 60)
            {
                minutes = (int)(timeLeft / 60);
                timertext.text = "" + ((int)minutes).ToString() + ":" + ((int)(timeLeft-(minutes*60))) + "." + ((int)vtimeleft).ToString();
            }
            else
            {
                minutes = 0;
            }
            if (timeLeft < 60 && timeLeft > 0)
                timertext.text = "" + ((int)timeLeft).ToString() +"."+ ((int)vtimeleft).ToString();
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
