using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 10.0f;
    public float rotation = 90.0f;
    public Transform camera;

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

        // Rotate the camera based on mouse movement
        transform.Rotate(new Vector3(0, mouseX * rotation * Time.deltaTime, 0));

    }
}
