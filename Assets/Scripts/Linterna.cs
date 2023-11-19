using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna_Script : MonoBehaviour
{
    public GameObject texto, linternaMesa, linternaMano;
    public bool b_interactuable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            texto.SetActive(true);
            b_interactuable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            texto.SetActive(false);
            b_interactuable = false;
        }
    }
    void Update()
    {
        if(b_interactuable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                texto.SetActive(false);
                b_interactuable = false;
               
                linternaMano.SetActive(true);
                linternaMesa.SetActive(false);
            }
        }
    }
}