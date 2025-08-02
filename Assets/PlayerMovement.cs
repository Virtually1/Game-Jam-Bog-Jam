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

    // Start is called before the first frame update
    void Start()
    {
         
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
        if (Input.GetKey(running))
        {
            speed = 10f;
        }
        else
        {
            speed = 5f; 
        }
        rb.velocity = new Vector2(horizontalSpeed * speed, verticalSpeed * speed);
    }
}
