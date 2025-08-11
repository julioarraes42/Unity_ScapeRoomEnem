using TMPro;
using UnityEngine;

public class LeitorSenhaControler : MonoBehaviour
{
    public GameObject digito;
    public int quantidadeDigitos = 0;
    public string senhaCorreta;
    public GameObject portaPivo;
    public GameObject painelSenha;

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
        }
        else
        {
            Debug.Log("Senha incorreta!");
        }
    }
}
