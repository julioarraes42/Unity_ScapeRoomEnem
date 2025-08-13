using UnityEngine;

public class QuadroDesafiosControlador : MonoBehaviour
{
    public GameObject controladorTela;
    public string pergunta1;
    public string[] respostas1;
    public string pergunta2;
    public string[] respostas2;
    public string pergunta3;
    public string[] respostas3;
    public int[] gabarito;

    public GameObject quadro;

    public bool blockeado = true;

    // Game objects para controlar a ui do quadro de desafios
    public GameObject quadroTrancado;
    public GameObject quadroDestrancado;
    public GameObject quadroSimbolo;

    public void IniciarDesafio()
    {
        controladorTela.GetComponent<CanvasDesafioControlador>().IniciarDesafio(
            pergunta1, respostas1, gabarito[0],
            pergunta2, respostas2, gabarito[1],
            pergunta3, respostas3, gabarito[2],
            quadro);
    }

    public void Destrancar()
    {
        quadroTrancado.SetActive(false);
        quadroDestrancado.SetActive(true);

        blockeado = false;
    }

    public void Concluir()
    {
        quadroDestrancado.SetActive(false);
        quadroSimbolo.SetActive(true);
        blockeado = true;
        //auto destruir
        Destroy(gameObject);
    }
}
