using UnityEngine;

public class QuadroSimbolosControler : MonoBehaviour
{
    public int numeracaoCelula = 0; // Vari�vel para armazenar a numera��o do celular
    public GameObject[] simbolos; // Array de GameObjects que representam os s�mbolos do quadro

    public void adicionarNumeroCelula()
    {
        numeracaoCelula += 1;

        if (numeracaoCelula >= 14)
        {
            simbolos[0].SetActive(true); // Ativa o primeiro s�mbolo quando a numera��o atinge 14
        }
    }

}
