using UnityEngine;

public class QuadroSimbolosControler : MonoBehaviour
{
    public int numeracaoCelula = 0; // Variável para armazenar a numeração do celular
    public GameObject[] simbolos; // Array de GameObjects que representam os símbolos do quadro
    public AudioSource audioSource; // Fonte de áudio para tocar o som de ativação dos símbolos
    public ParticleSystem particleSystem; // Referência ao sistema de partículas para efeitos visuais

    public void adicionarNumeroCelula()
    {
        numeracaoCelula += 1;

        if (numeracaoCelula >= 14)
        {
            // Toca o áudio de ativação dos símbolos quando a numeração atinge 14
            audioSource.Play();
            particleSystem.Play(); // Inicia o sistema de partículas para efeitos visuais
            simbolos[0].SetActive(true); // Ativa o primeiro símbolo quando a numeração atinge 14
        }
    }

}
