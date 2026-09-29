using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle5Controler : MonoBehaviour
{
    [SerializeField] private GameObject tela;
    [SerializeField] private GameObject[] IconesDesativados;
    [SerializeField] private GameObject[] IconesAtivados;
    [SerializeField] private PlayerComandos playerComandos;

    [SerializeField] private float velocidadeAnimacao = 0f;

    public Animator animator;

    public int etapaAtual = 0;
    public bool ativo = false;
    public bool animacaoAtiva = false;
    public float tempo = 0f;

    private void Start()
    {
        animator.Play("DNACanvas", 0, 0f);
        velocidadeAnimacao = 0f;
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
    }
}
