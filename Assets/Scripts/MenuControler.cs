using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inteface;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resumir();
        }
    }

    // Bottoes do menu
    
    public void Resumir(){
        GetComponent<PlayerComandos>().menuAberto = !GetComponent<PlayerComandos>().menuAberto;
        if (GetComponent<PlayerComandos>().menuAberto)
        {
            Cursor.lockState = CursorLockMode.None; // Libera o cursor
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // Trava o cursor novamente
        }
        mainMenu.SetActive(!mainMenu.activeSelf);
        inteface.SetActive(!inteface.activeSelf);
    }

    public void Resetar()
    {
        Scene cenaAtual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cenaAtual.name);
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saindo do jogo...");
    }
}
