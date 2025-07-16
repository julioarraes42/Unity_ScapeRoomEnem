using UnityEngine;

public class QuadroSimbolosControler : MonoBehaviour
{
    public int numeracaoCelula = 0; // Vari�vel para armazenar a numera��o do celular
    public GameObject[] simbolos; // Array de GameObjects que representam os s�mbolos do quadro
    public AudioSource audioSource; // Fonte de �udio para tocar o som de ativa��o dos s�mbolos
    public ParticleSystem particleSystem; // Refer�ncia ao sistema de part�culas para efeitos visuais

    public void adicionarNumeroCelula()
    {
        numeracaoCelula += 1;

        if (numeracaoCelula >= 14)
        {
            // Toca o �udio de ativa��o dos s�mbolos quando a numera��o atinge 14
            audioSource.Play();
            particleSystem.Play(); // Inicia o sistema de part�culas para efeitos visuais
            simbolos[0].SetActive(true); // Ativa o primeiro s�mbolo quando a numera��o atinge 14
        }
    }

}
