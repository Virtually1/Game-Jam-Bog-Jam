using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float horizontalSpeed;
    public Rigidbody2D rb;
    public KeyCode running = KeyCode.LeftShift;
    public float verticalSpeed;
    public float energy = 100f;
    public EnergyBar energyBar;
    public float timer = 0f;
    public bool isrecharging = false;
    // Start is called before the first frame update
    void Start()
    {
        energyBar.SetMaxEnergy(100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

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
        energyBar.SetEnergy((int)energy);

    }
    public void energyrecharge()
    {

        timer += Time.deltaTime;
            if (timer > 1f)
            {
                energy += 4;
                timer = 0;
            }
            energyBar.SetEnergy((int)energy);

        if (energy > 100f)
        {
            energy = 100f;
            isrecharging = false;
        }
    }
}
