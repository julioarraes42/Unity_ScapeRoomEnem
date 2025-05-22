using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 10.0f;
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

        Vector3 dir = new Vector3(x, 0, y) * velocity;

        transform.Translate(dir * Time.deltaTime);


        transform.Rotate(new Vector3(0, mouseX * rotation * Time.deltaTime, 0));

        bool movimento = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

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
    }
}
