
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float horizontalSpeed;
    public Rigidbody2D rb;
    public KeyCode running = KeyCode.LeftShift;
    public float verticalSpeed;
    public float energy = 100f;
    public float timer = 0f;
    public bool isrecharging = false;
    public GameObject[] img = new GameObject[4];
    public TextMeshProUGUI procent;
    public int bars;
    public int nobars;
    public RawImage imgs;
    public int score;
    public TextMeshProUGUI scoretext;
    // Start is called before the first frame update
    void Start()
    {
        score= 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoretext.text = score.ToString();
        energybar();
        Movement();
    }
    public void Movement()
    {
        if(isrecharging)
        {
            speed = 0f;
            energyrecharge();
        }
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(running) && energy > 15&& isrecharging == false)
        {
            speed = 10f;
            energydrain();
        }
        else if(isrecharging == false)
        {
            speed = 6f;
        }
        if (horizontalSpeed != 0)
        {
            verticalSpeed = 0;
        }
        if (verticalSpeed != 0)
        {
            horizontalSpeed = 0;
        }
        //if (!(horizontalSpeed != 0 && verticalSpeed != 0))
        {
            rb.velocity = new Vector2(horizontalSpeed * speed, verticalSpeed * speed);
        }

    }
    public void energydrain()
    {
        energy -= Time.deltaTime * 3;
        

    }
    public void energybar()
    {
        bars = (int)Mathf.Ceil(energy / 25);
        nobars = (int)Mathf.Floor((100 - energy) / 25);
        for (int i = 0; i < bars; i++)
        {
            img[i].gameObject.SetActive(true);
        }
        for (int i = 4 - nobars; i < 4; i++)
        {
            img[i].gameObject.SetActive(false);
        }

        if(bars>1)
        {
            for(int i = 0;i<img.Length;i++)
            {
                 img[i].GetComponent<RawImage>().color = Color.white;
            }
        }
        else 
        {
            for (int i = 0; i < img.Length; i++)
            {
                img[i].GetComponent<RawImage>().color = Color.red;
            }
            
        }
            procent.text = ((int)energy).ToString() + "%";
    }
    public void energyrecharge()
    {

        timer += Time.deltaTime;
            if (timer > 1f)
            {
                energy += 7;
                timer = 0;
            }

        if (energy > 100f)
        {
            energy = 100f;
            isrecharging = false;
        }
    }
}
