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
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(running) && energy > 1)
        {
            speed = 10f;
            energydrain();
        }
        else
        {
            speed = 7f;
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
        while (energy < 100f)
        {
            energy += Time.deltaTime * 7;
        }
        if (energy > 100f)
        {
            energy = 100f;
        }
    }
}
