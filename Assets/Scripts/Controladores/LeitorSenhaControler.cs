using TMPro;
using UnityEngine;

public class LeitorSenhaControler : MonoBehaviour
{
    public GameObject digito;
    public int quantidadeDigitos = 0;
    public string senhaCorreta;
    public GameObject portaPivo;
    public GameObject painelSenha;

    public GameObject player; // Referência ao jogador

    public GameObject puzzleControler;

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
        }
        else
        {
            Debug.Log("Senha incorreta!");
        }
    }

    public void Iniciar()
    {
        painelSenha.SetActive(true);
        player.GetComponent<PlayerComandos>().menuAberto = true; // Abre o menu do jogador
        Cursor.lockState = CursorLockMode.None; // Libera o cursor

    }
}
