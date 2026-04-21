using UnityEngine;
using UnityEngine.UI;

public class PuzzleCelulaControlador : MonoBehaviour
{
    private int contagem = 0;
    public GameObject quadro1;
    public GameObject quadro2;
    public GameObject quadro3;
    public GameObject quadro4;
    public GameObject quadro5;
    public GameObject quadro6;
    public GameObject[] cadeadosTrancado;
    public GameObject[] cadeadosDestrancados;
    public RawImage[] fundos;

    public void AdicionarContagem()
    {
               contagem++;
        if (contagem >= 14)
        {
            quadro1.GetComponent<QuadroDesafiosControlador>().Destrancar();
            cadeadosTrancado[0].SetActive(false);
            cadeadosDestrancados[0].SetActive(true);
            fundos[0].color = Color.white;
        }
    }
    public void AbrirQuadro2()
    {
        quadro2.GetComponent<QuadroDesafiosControlador>().Destrancar();
        cadeadosTrancado[1].SetActive(false);
        cadeadosDestrancados[1].SetActive(true);
        fundos[1].color = Color.white;
    }

    public void AbrirQuadro3()
    {
        quadro3.GetComponent<QuadroDesafiosControlador>().Destrancar();
        cadeadosTrancado[2].SetActive(false);
        cadeadosDestrancados[2].SetActive(true);
        fundos[2].color = Color.white;
    }
    public void AbrirQuadro4()
    {
        quadro4.GetComponent<QuadroDesafiosControlador>().Destrancar();
        cadeadosTrancado[3].SetActive(false);
        cadeadosDestrancados[3].SetActive(true);
        fundos[3].color = Color.white;
    }
    public void AbrirQuadro5()
    {
        quadro5.GetComponent<QuadroDesafiosControlador>().Destrancar();
        cadeadosTrancado[4].SetActive(false);
        cadeadosDestrancados[4].SetActive(true);
        fundos[4].color = Color.white;
    }
    public void AbrirQuadro6()
    {
        quadro6.GetComponent<QuadroDesafiosControlador>().Destrancar();
        cadeadosTrancado[5].SetActive(false);
        cadeadosDestrancados[5].SetActive(true);
        fundos[5].color = Color.white;
    }



}
