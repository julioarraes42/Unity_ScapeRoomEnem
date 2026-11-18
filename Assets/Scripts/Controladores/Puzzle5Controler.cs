using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle5Controler : MonoBehaviour
{
    [SerializeField] private float velocidadeAnimacao = 0f;
    
    public Button[] botoes;

    public string[] opcoes = {
        "Desnaturação",
        "Anelamento",
        "Extensão",
        "Replicação",
        "Transcrição",
        "Tradução",
        "Hibridização",
        "Eletroforese",
        "Centrifugação",
        "Purificação",
        "Ligação",
        "Clonagem"
    };

    public int[] sorteio = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};

    public Animator animator;

    public int etapaAtual = 0;
    public bool ativo = false;
    public bool animacaoAtiva = false;
    public float tempo = 0f;

    private void Start()
    {
        animator.Play("DNACanvas", 0, 0f);
        velocidadeAnimacao = 0f;

        Embaralhar();
    }

    private void Update()
    {

        animator.speed = velocidadeAnimacao;

        AnimatorStateInfo estado = animator.GetCurrentAnimatorStateInfo(0);

        tempo = estado.normalizedTime % 1f;

        if (!animacaoAtiva)
        {
            velocidadeAnimacao = 0f;
        }
        else if (etapaAtual == 0 && animacaoAtiva && tempo > 0.99f)
        {
            animator.Play("DNACanvas", 0, 0f);
            animacaoAtiva = false;
        }
        else if (etapaAtual == 1 && tempo >= 0.25f && tempo <= 0.625f && animacaoAtiva == true)
        {
            velocidadeAnimacao = 0f;
        }
        else if (etapaAtual == 2 && tempo >= 0.625f)
        {
            velocidadeAnimacao = 0f;
        }

    }

    public void botao(int valor)
    {

        if (etapaAtual == valor)
        {
            if (etapaAtual == 0)
            {
                tempo = 0f;
                animator.Play("DNACanvas", 0, 0f);
                animacaoAtiva = true;
                etapaAtual++;
                velocidadeAnimacao = 1f;
            }
            else if (etapaAtual == 1)
            {
                tempo = 0.375f;
                animator.Play("DNACanvas", 0, 0.375f);
                velocidadeAnimacao = 1f;
                etapaAtual++;
            }
            else if (etapaAtual == 2)
            {
                etapaAtual = 0;
                velocidadeAnimacao = 1f;
                tempo = 0.75f;
                animator.Play("DNACanvas", 0, 0.75f);
            }
        }
        else
        {
            etapaAtual = 0;
            velocidadeAnimacao = 0f;
            tempo = 0.0f;
            animator.Play("DNACanvas", 0, 0.0f);

            Embaralhar();
        }
    }

    public void Embaralhar()
    {

        for (int i = 0; i < sorteio.Length; i++)
        {
            int indiceAleatorio = Random.Range(i, sorteio.Length);

            int temp = sorteio[i];
            sorteio[i] = sorteio[indiceAleatorio];
            sorteio[indiceAleatorio] = temp;
        }

        for (int i = 0; i < botoes.Length; i++)
        {
            int indice = i;

            botoes[sorteio[i]].onClick.RemoveAllListeners();

            botoes[sorteio[i]].onClick.AddListener(() => botao(indice));
            botoes[sorteio[i]].GetComponentInChildren<TMP_Text>().text = opcoes[i];

            botoes[sorteio[i]].GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 0.9f, 1f, 0.5f, 1f);
        }
    }
}
