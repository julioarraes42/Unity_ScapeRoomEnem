using UnityEngine;

public class PuzzleCelulaControlador : MonoBehaviour
{
    private int contagem = 0;
    public GameObject quadro1;
    public GameObject quadro2;
    public GameObject quadro3;
    public GameObject quadro4;

    public void AdicionarContagem()
    {
               contagem++;
        if (contagem >= 14)
        {
            quadro1.GetComponent<QuadroDesafiosControlador>().Destrancar();
        }
    }

    public void AbrirQuadro2()
    {
        quadro2.GetComponent<QuadroDesafiosControlador>().Destrancar();
    }

    public void AbrirQuadro3()
    {
        quadro3.GetComponent<QuadroDesafiosControlador>().Destrancar();
    }
    public void AbrirQuadro4()
    {
        quadro4.GetComponent<QuadroDesafiosControlador>().Destrancar();
    }



    }
