
using UnityEngine;

public class Recharging : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canrecharge = false;
    public PlayerMovement pm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       canrecharge = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Recharge"));
        if(canrecharge&& pm.energy< 100&&Input.GetKeyDown(KeyCode.R))
        {
           if(Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Recharge")))
            {
                pm.isrecharging = true;
            }
        }
    }
}
