
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft = 120f;
    public TextMeshProUGUI timertext;
    public float vtimeleft;
    public float minutes;
    public Load Load;
    // Start is called before the first frame update
    void Start()
    {
        if(StaticData.difficulty!=0)
        timeLeft = 120 * (4 - StaticData.difficulty);
        
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
        SaveSystem.Save();
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Time's up!");
    }
}
