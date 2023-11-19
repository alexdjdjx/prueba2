using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject texto;
    public bool b_interactuable, b_toggle;
    public Animator anim_door;

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
                b_toggle = !b_toggle;
                if(b_toggle == true)
                {
                    anim_door.ResetTrigger("cerrar");
                    anim_door.SetTrigger("abrir");
                }
                if (b_toggle == false)
                {
                    anim_door.ResetTrigger("abrir");
                    anim_door.SetTrigger("cerrar");
                }
                texto.SetActive(false);
                b_interactuable = false;
            }
        }
    }
}