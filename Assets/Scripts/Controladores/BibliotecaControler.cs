using UnityEngine;

public class BibliotecaControler : MonoBehaviour
{
    public GameObject bibliotecaPanel; // Painel principal da biblioteca
    public GameObject[] livrosPanel; // Paineis dos livros
    public GameObject[] HudPaineis; // Paineis da HUD
    public int livroAtual = -1; // Índice do livro atualmente aberto
    public bool bibliotecaaberta = false;
    public GameObject hudbotao; // Botão da HUD para sair da biblioteca

    public void AbrirBiblioteca()
    {
        bibliotecaPanel.SetActive(true);
        bibliotecaaberta = true;
        foreach (GameObject painel in HudPaineis)
        {
            painel.SetActive(false);
        }

        hudbotao.SetActive(true);
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

            bibliotecaaberta = false;

            Cursor.lockState = CursorLockMode.Locked;

            hudbotao.SetActive(false);
        }
    }
}
