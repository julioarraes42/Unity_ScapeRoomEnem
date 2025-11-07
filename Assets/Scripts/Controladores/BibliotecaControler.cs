using UnityEngine;

public class BibliotecaControler : MonoBehaviour
{
    public GameObject bibliotecaPanel; // Painel principal da biblioteca
    public GameObject[] livrosPanel; // Paineis dos livros
    public GameObject[] HudPaineis; // Paineis da HUD
    public int livroAtual = -1; // Índice do livro atualmente aberto


    public void AbrirBiblioteca()
    {
        bibliotecaPanel.SetActive(true);
        foreach (GameObject painel in HudPaineis)
        {
            painel.SetActive(false);
        }
    }

    public void AbrirLivro(int livro)
    {
        livrosPanel[livro].SetActive(true);
        livroAtual = livro;
        bibliotecaPanel.SetActive(false);
    }

    public void Fechar()
    {
        if (livroAtual != -1)
        {
            livrosPanel[livroAtual].SetActive(false);
            bibliotecaPanel.SetActive(true);
            livroAtual = -1;
        }
        else
        {
            bibliotecaPanel.SetActive(false);
            foreach (GameObject painel in HudPaineis)
            {
                painel.SetActive(true);
            }
        }
    }
}
