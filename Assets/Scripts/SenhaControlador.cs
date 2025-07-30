using TMPro;
using UnityEngine;

public class SenhaControlador : MonoBehaviour
{
    public GameObject[] valores;
    public string senhaCorreta; // Defina a senha correta aqui

    public bool Verificar()
    {
        string senha = "";
        for (int i = 0; i < valores.Length; i++)
        {
            senha += valores[i].GetComponent<TextMeshProUGUI>().text;
        }

        if (senha == senhaCorreta)
        {
            Debug.Log("Senha correta!");
            return true; // Senha correta
        }
        else
        {
            Debug.Log("Senha incorreta!");
            return false; // Senha incorreta
        }
    }
}
