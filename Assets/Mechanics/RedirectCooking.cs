using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectCooking : MonoBehaviour
{
    public Cooking cook;
    public int c;
    public FoodReq req;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pot()
    {
         
        if (this.name == "Tomato")
        {
            cook.potid[c] = 1;
            Debug.Log("To");
        }
        else if (this.name == "Ingredient 2")
        {
            cook.potid[c] = 2;
            Debug.Log("Ca");
        }
        else if (this.name == "Lettuce")
        {
            cook.potid[c] = 3;
        }
        this.gameObject.SetActive(false);

        c++;
    }    
}
