using UnityEngine;

public class IconeItens : MonoBehaviour
{
    public Transform mainCamera; // Refer�ncia � c�mera principal

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera); // Faz o �cone olhar para a c�mera principal
            transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.position); // Ajusta a rota��o para que o �cone fique sempre voltado para a c�mera
        }
        
    }
}
