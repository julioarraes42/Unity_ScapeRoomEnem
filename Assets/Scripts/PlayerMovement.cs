using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade;
    private float velocidadeAtual;
    public float rotation = 90.0f;
    public Transform camera;
    public AudioSource passosAudio;
    public Light lanterna;
    public bool lanternaLigada = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        lanterna.enabled = false;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        bool estaCorrendo;
        bool movimento = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (Input.GetKeyDown(KeyCode.F))
        {
            lanternaLigada = !lanternaLigada;
            lanterna.enabled = lanternaLigada;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeAtual = velocidade * 2;
            passosAudio.pitch = 1.5f;
        }
        else
        {
            velocidadeAtual = velocidade;
            passosAudio.pitch = 1.0f;
        }

        if (movimento)
        {
            if (!passosAudio.isPlaying)
            {
                passosAudio.Play();
            }
        }
        else
        {
            if (passosAudio.isPlaying)
            {
                passosAudio.Stop();
            }
        }

        Vector3 dir = new Vector3(x, 0, y) * velocidadeAtual;

        transform.Translate(dir * Time.deltaTime);


        transform.Rotate(new Vector3(0, mouseX * rotation * Time.deltaTime, 0));
    }
}
