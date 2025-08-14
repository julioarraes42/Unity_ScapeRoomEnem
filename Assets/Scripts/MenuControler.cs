using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inteface;
    private bool menuAberto = false;
    private bool cursorLiberado = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resumir();
        }
    }

    // Bottoes do menu
    
    public void Resumir(){

        if (cursorLiberado)
        {
            Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; // Libera o cursor
            menuAberto = GetComponent<PlayerComandos>().menuAberto;
        }
        mainMenu.SetActive(!mainMenu.active);
        inteface.SetActive(!inteface.active);
        cursorLiberado = !cursorLiberado; // Inverte o estado do cursor

        if (!menuAberto)
        {
            GetComponent<PlayerComandos>().menuAberto = !GetComponent<PlayerComandos>().menuAberto;
        }
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
