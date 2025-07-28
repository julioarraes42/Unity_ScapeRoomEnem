using UnityEngine;

public class Porta : MonoBehaviour
{
    private Animator animator;
    private bool aberta = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interacao()
    {
        if (aberta)
        {
            animator.SetTrigger("Fechar");
        }
        else
        {
            animator.SetTrigger("Abrir");
        }
        aberta = !aberta;
    }
}
