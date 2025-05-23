using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade;
    private float velocidadeAtual;
    public float rotation = 90.0f;
    public Transform camera;
    public AudioSource passosAudio;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        bool estaCorrendo;
        bool movimento = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);


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
