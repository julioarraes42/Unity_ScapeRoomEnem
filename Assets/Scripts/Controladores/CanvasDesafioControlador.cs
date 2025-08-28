using TMPro;
using UnityEngine;

public class CanvasDesafioControlador : MonoBehaviour
{
    public GameObject tela;
    public GameObject textoPergunta;
    public GameObject[] TextobotoesRespostas;
    private int perguntaAtual;
    private int respostaAtual;

    public string[] perguntas;
    public string[][] respostas = new string[3][];
    public int[] gabarito;

    // Game objects para controle do player
    public GameObject player;

    // Referencia ao quadro de desafios
    public GameObject quadro;

    public void IniciarDesafio(string pergunta1, string[] resposta1, int respostaCorreta1,
        string pergunta2, string[] resposta2, int respostaCorreta2, 
        string pergunta3, string[] resposta3, int respostaCorreta3,
        GameObject quadroVar)
    {
        tela.SetActive(true);
        perguntaAtual = 0;

        this.perguntas = new string[] { pergunta1, pergunta2, pergunta3 };

        this.respostas[0] = resposta1;
        this.respostas[1] = resposta2;
        this.respostas[2] = resposta3;

        gabarito = new int[] { respostaCorreta1, respostaCorreta2, respostaCorreta3 };

        quadro = quadroVar;

        AtualizarPergunta();

        // Desblockeia o cursor do centro da tela
        Cursor.lockState = CursorLockMode.None;
    }

    public void FecharDesafio(bool concluido)
    {
        tela.SetActive(false);
        player.GetComponent<PlayerComandos>().menuAberto = false;

        if (concluido)
        {
            quadro.GetComponent<QuadroDesafiosControlador>().Concluir();
        }
        // Bloqueia o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AtualizarPergunta()
    {
        textoPergunta.GetComponent<TextMeshProUGUI>().text = perguntas[perguntaAtual];
        for (int i = 0; i < TextobotoesRespostas.Length; i++)
        {
            TextobotoesRespostas[i].GetComponent<TextMeshProUGUI>().text = respostas[perguntaAtual][i];
        }
        respostaAtual = gabarito[perguntaAtual];
    }

    public void Resposta(int resposta)
    {
        Debug.Log("Resposta selecionada: " + resposta + ", Resposta correta: " + respostaAtual);

        if (resposta == respostaAtual)
        {
            perguntaAtual++;
            if (perguntaAtual < 3)
            {
                AtualizarPergunta();
            }
            else
            {
                FecharDesafio(true);
            }

        } else
        {
            FecharDesafio(false);
        }
    }



}
