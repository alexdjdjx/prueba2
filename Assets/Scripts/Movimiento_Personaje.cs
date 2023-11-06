using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float velocidadCaminar = 7.5f;
    public float velocidadCorrer = 11.5f;
    public Camera camaraJugador;
    public float sensibilidadRaton = 2.0f;

    CharacterController controladorPersonaje;
    Vector3 direccionMovimiento = Vector3.zero;
    float rotacionX = 0;

    [HideInInspector]
    public bool puedeMoverse = true;

    void Start()
    {
        controladorPersonaje = GetComponent<CharacterController>();

        // Bloquear cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 adelante = transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical");
        Vector3 derecha = transform.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal");

        // Presiona Shift para correr
        bool estaCorriendo = Input.GetKey(KeyCode.LeftShift);
        float velocidadActualX = puedeMoverse ? (estaCorriendo ? velocidadCorrer : velocidadCaminar) : 0;

        direccionMovimiento = (adelante + derecha).normalized * velocidadActualX;

        // Mover el controlador
        controladorPersonaje.Move(direccionMovimiento * Time.deltaTime);

        // Rotación del jugador y la cámara
        if (puedeMoverse)
        {
            rotacionX += -Input.GetAxis("Mouse Y") * sensibilidadRaton;
            rotacionX = Mathf.Clamp(rotacionX, -45f, 45f);
            camaraJugador.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);

          
        }
          float rotacionY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensibilidadRaton;
        transform.localEulerAngles = new Vector3(0, rotacionY, 0);
        controladorPersonaje.Move(direccionMovimiento * Time.deltaTime);
    }
}
