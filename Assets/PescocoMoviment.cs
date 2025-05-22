using UnityEngine;

public class PescocoMoviment : MonoBehaviour
{
    public float rotation = 90.0f;
    public float eixoZ = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        // Rotate the camera based on mouse movement
        transform.Rotate(new Vector3(0,mouseX * rotation * Time.deltaTime, 0));

    }
}
