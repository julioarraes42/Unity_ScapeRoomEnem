using UnityEngine;

public class IconeItens : MonoBehaviour
{
    public Transform mainCamera; // Referência à câmera principal

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera); // Faz o ícone olhar para a câmera principal
            transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.position); // Ajusta a rotação para que o ícone fique sempre voltado para a câmera
        }
        
    }
}
