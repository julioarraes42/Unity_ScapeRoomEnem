using UnityEngine;

public class CofreSenhaControlador : MonoBehaviour
{
    public GameObject tela;
    public GameObject[] digitos;
    public GameObject[] UIs; //Objetos de UIs que irão desativar quando aberto
    public GameObject[] UIsFechar; //Objetos de UIs que irão ativados quando aberto
    public string senha;
    public GameObject player;
    public bool aberto = false;

    public GameObject cofre;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (aberto)
            {
                fechar();
            }
        }
    }

    void Start()
    {
        tela.SetActive(false);
    }

    public void iniciar()
    {
        player.GetComponent<PlayerComandos>().menuAberto = true;

        aberto = true;

        Cursor.lockState = CursorLockMode.None;

        tela.SetActive(true);

        for (int i = 0; i < digitos.Length; i++)
        {
            digitos[i].GetComponent<CofreDigito>().Iniciar();

            Debug.Log(digitos[i].GetComponent<CofreDigito>().numero);
        }

        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(false);
        }

        for (int i = 0; i < UIsFechar.Length; i++)
        {
            UIsFechar[i].SetActive(true);
        }

        tela.SetActive(true);
    }

    public void fechar()
    {
        player.GetComponent<PlayerComandos>().menuAberto = false;

        aberto = false;

        tela.SetActive(false);

        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(true);
        }

        for (int i = 0; i < UIsFechar.Length; i++)
        {
            UIsFechar[i].SetActive(false);
        }

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
            cofre.GetComponent<BoxCollider>().enabled = false;

            cofre.GetComponent<Animator>().SetTrigger("Ativar");

            fechar();
        }
    }

}
