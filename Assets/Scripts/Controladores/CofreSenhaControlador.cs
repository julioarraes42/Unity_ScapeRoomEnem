using UnityEngine;

public class CofreSenhaControlador : MonoBehaviour
{
    public GameObject tela;
    public GameObject[] digitos;
    public string senha;
    public GameObject player;
    public bool aberto = false;

    public GameObject cofre;

    private void Update()
    {
        
///        if (Input.GetKeyDown(KeyCode.E) && tela.activeSelf)
///        {
///            fechar();
///        }
    }

    void Start()
    {
        tela.SetActive(false);
    }

    public void iniciar()
    {
        player.GetComponent<PlayerComandos>().menuAberto = true;

        Cursor.lockState = CursorLockMode.None;

        tela.SetActive(true);

        for (int i = 0; i < digitos.Length; i++)
        {
            digitos[i].GetComponent<CofreDigito>().Iniciar();

            Debug.Log(digitos[i].GetComponent<CofreDigito>().numero);
        }

        tela.SetActive(true);
    }

    public void fechar()
    {
        player.GetComponent<PlayerComandos>().menuAberto = false;

        tela.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void verifica()
    {
        string tentativa = "";

        for (int i = 0; i < digitos.Length; i++)
        {
            tentativa += digitos[i].GetComponent<CofreDigito>().numero.ToString();
        }

        if (tentativa == senha)
        {

            aberto = true;
            cofre.GetComponent<BoxCollider>().enabled = false;

            cofre.GetComponent<Animator>().SetTrigger("Ativar");

            fechar();
        }
        else
        {

            fechar();
        }
    }

}
