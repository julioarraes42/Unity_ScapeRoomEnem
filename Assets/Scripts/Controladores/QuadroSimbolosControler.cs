using UnityEngine;

public class QuadroSimbolosControler : MonoBehaviour
{
    public int numeracaoCelula = 0; // Variável para armazenar a numeração do celular
    public GameObject[] simbolos; // Array de GameObjects que representam os símbolos do quadro

    public void adicionarNumeroCelula()
    {
        numeracaoCelula += 1;

        if (numeracaoCelula >= 14)
        {
            simbolos[0].SetActive(true); // Ativa o primeiro símbolo quando a numeração atinge 14
        }
    }

}
