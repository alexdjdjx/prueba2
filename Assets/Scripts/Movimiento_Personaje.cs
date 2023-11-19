using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float fl_velocidadCaminar = 5f;
    public float fl_velocidadCorrer = 8f;
    public Camera camaraJugador;
    public float fl_sensibilidadRaton = 2.0f;

    CharacterController controladorPersonaje;
    Vector3 v3_direccionMovimiento = Vector3.zero;
    float fl_rotacionX = 0;

    [HideInInspector]
    public bool b_puedeMoverse = true;

    void Start()
    {
        controladorPersonaje = GetComponent<CharacterController>();

       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 v3_adelante = transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical");
        Vector3 v3_derecha = transform.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal");

       
        bool b_estaCorriendo = Input.GetKey(KeyCode.LeftShift);
        float fl_velocidadActualX = b_puedeMoverse ? (b_estaCorriendo ? fl_velocidadCorrer : fl_velocidadCaminar) : 0;

        v3_direccionMovimiento = (v3_adelante + v3_derecha).normalized * fl_velocidadActualX;

     
        controladorPersonaje.Move(v3_direccionMovimiento * Time.deltaTime);

        
        if (b_puedeMoverse)
        {
            fl_rotacionX += -Input.GetAxis("Mouse Y") * fl_sensibilidadRaton;
            fl_rotacionX = Mathf.Clamp(fl_rotacionX, -45f, 45f);
            camaraJugador.transform.localRotation = Quaternion.Euler(fl_rotacionX, 0, 0);

          
        }
        float fl_rotacionY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * fl_sensibilidadRaton;
        transform.localEulerAngles = new Vector3(0, fl_rotacionY, 0);
        controladorPersonaje.Move(v3_direccionMovimiento * Time.deltaTime);
    }
}
