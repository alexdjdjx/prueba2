using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public GameObject texto, light;
    public bool b_toggle = true, b_interactuable;
    public Renderer luzArriba;
    public Material offlight, onlight;
    public Animator anim_switch;

void Start(){
    texto.SetActive(false);
}
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
          
                anim_switch.ResetTrigger("press");
                anim_switch.SetTrigger("press");
            }
        }
        if(b_toggle == false)
        {
            light.SetActive(false);
            luzArriba.material = offlight;
        }
        if (b_toggle == true)
        {
            light.SetActive(true);
            luzArriba.material = onlight;
        }
    }
}