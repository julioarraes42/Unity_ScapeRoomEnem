using TMPro;
using UnityEngine;

public class LeitorSenhaControler : MonoBehaviour
{
    public GameObject digito;
    public int quantidadeDigitos = 0;
    public string senhaCorreta;
    public bool painelAtivo = false;
    public GameObject portaPivo;
    public GameObject painelSenha;

    public GameObject player; // Referência ao jogador

    public GameObject puzzleControler;

    public GameObject[] paineis; // Referencia paineis que serão desligados
    public GameObject[] paineisLigados; // Referencia paineis que serão ligados


    private void Update()
    {
        if (painelAtivo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Desativar();
            }
        }
    }

    public void Adicionar(int valor)
    {
        if (quantidadeDigitos < 4)
        {
            digito.GetComponent<TextMeshProUGUI>().text += valor.ToString();
            quantidadeDigitos++;
        }
    }

    public void Limpar()
    {
        digito.GetComponent<TextMeshProUGUI>().text = string.Empty;
        quantidadeDigitos = 0;
    }

    public void ConferirSenha()
    {
         if (digito.GetComponent<TextMeshProUGUI>().text == senhaCorreta)
        {
            portaPivo.GetComponent<Porta>().Interacao();
            painelSenha.SetActive(false);
            puzzleControler.GetComponent<PuzzleCelulaControlador>().AbrirQuadro4();
            player.GetComponent<PlayerComandos>().menuAberto = false; // Fecha o menu do jogador
            Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela

            for (int i = 0; i < paineis.Length; i++)
            {
                paineis[i].SetActive(true);
            }

            painelAtivo = false;
        }
        else
        {
            Debug.Log("Senha incorreta!");
        }
    }

    public void Iniciar()
    {
        painelSenha.SetActive(true);
        player.GetComponent<PlayerComandos>().menuAberto = true;
        Cursor.lockState = CursorLockMode.None; // Libera o cursor

        for (int i = 0; i < paineis.Length; i++)
        {
            paineis[i].SetActive(false);
        }

        for (int i = 0; i < paineisLigados.Length; i++)
        {
            paineisLigados[i].SetActive(true);
        }
        painelAtivo = true;

    }

    public void Desativar()
    {
        painelSenha.SetActive(false);
        player.GetComponent<PlayerComandos>().menuAberto = false; // Fecha o menu do jogador
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela

        for (int i = 0; i < paineis.Length; i++)
        {
            paineis[i].SetActive(true);
        }

        for (int i = 0; i < paineisLigados.Length; i++)
        {
            paineisLigados[i].SetActive(false);
        }

        painelAtivo = false;
    }
}
