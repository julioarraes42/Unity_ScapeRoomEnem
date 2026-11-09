using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour
{
    [SerializeField] private bool ativado = false;
    [SerializeField] GameObject tela;
    public Sprite[] sprites;
    public Image imagem;
    public GameObject[] buttons;
    public PlayerComandos playerComandos;
    public GameObject[] destivados;
    public GameObject[] ativados;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FecharTela();
        }
    }
    public void AtivarBanner()
    {
        if (!ativado)
        {
            ativado = true;
            GetComponent<Renderer>().material.SetFloat("_Ativar", 1f);
        }
    }

    public void DesativarBanner()
    {
        if (ativado)
        {
            ativado = false;
            GetComponent<Renderer>().material.SetFloat("_Ativar", 0f);
        }
    }

    public void AbrirTela()
    {
        tela.SetActive(true);
        playerComandos.inventarioAberto = true;
        Cursor.lockState = CursorLockMode.None;
        buttons[0].SetActive(false);
        imagem.sprite = sprites[0];

        for (int i = 0; i < destivados.Length; i++)
        {
            destivados[i].SetActive(false);
        }

        for (int i = 0; i < ativados.Length; i++)
        {
            ativados[i].SetActive(true);
        }
    }

    public void FecharTela()
    {
        playerComandos.inventarioAberto = false;
        Cursor.lockState = CursorLockMode.Locked;
        tela.SetActive(false);

        for (int i = 0; i < destivados.Length; i++)
        {
            destivados[i].SetActive(true);
        }

        for (int i = 0; i < ativados.Length; i++)
        {
            ativados[i].SetActive(false);
        }
    }

    public void TrocarImagem(int valor)
    {
        if(valor == 0)
        {
            buttons[0].SetActive(false);
            buttons[1].SetActive(true);
            imagem.sprite = sprites[valor];
        }
        else if (valor == (sprites.Length - 1))
        {
            buttons[1].SetActive(false);
            buttons[0].SetActive(true);
            imagem.sprite = sprites[valor];
        }
        else
        {
            buttons[1].SetActive(true);
            buttons[0].SetActive(true);
        }
    }
}
