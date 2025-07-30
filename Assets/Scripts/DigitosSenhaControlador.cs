using TMPro;
using UnityEngine;

public class DigitosSenhaControlador : MonoBehaviour
{
    public int valorAtual = 0;

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = valorAtual.ToString();
    }

    public void Adicionar()
    {
        if(valorAtual < 9)
        {
            valorAtual++;
        }

        GetComponent<TextMeshProUGUI>().text = valorAtual.ToString();
    }

    public void Subtrair()
    {
        if(valorAtual > 0)
        {
            valorAtual--;
        }
        GetComponent<TextMeshProUGUI>().text = valorAtual.ToString();
    }

    public void Resetar()
    {
        valorAtual = 0;
        GetComponent<TextMeshProUGUI>().text = valorAtual.ToString();
    }
}
