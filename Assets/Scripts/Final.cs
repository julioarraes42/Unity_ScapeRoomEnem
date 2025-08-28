using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colidiu com: " + other.tag);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Parabéns! Você venceu o jogo!");
            Application.Quit();
        }
    }
}
