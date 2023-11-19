using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject light;
    public bool b_toggle;
    

    void Start()
    {
        if(b_toggle == false)
        {
            light.SetActive(false);
        }
        if (b_toggle == true)
        {
            light.SetActive(true);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            b_toggle = !b_toggle;
           
            if(b_toggle == false)
            {
                light.SetActive(false);
            }
            if (b_toggle == true)
            {
                light.SetActive(true);
            }
        }
    }
}