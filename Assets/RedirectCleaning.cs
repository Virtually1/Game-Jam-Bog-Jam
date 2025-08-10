using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedirectCleaning : MonoBehaviour
{
    public Cleaning cl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Redirect()
    {
        Destroy(this.gameObject);
        cl.count++;
        cl.clean();
    }
}
