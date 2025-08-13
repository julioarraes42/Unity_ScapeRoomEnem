using UnityEngine;

public class PuzzleCelulaControlador : MonoBehaviour
{
    private int contagem = 0;
    public GameObject quadro;

    public void AdicionarContagem()
    {
               contagem++;
        if (contagem >= 14)
        {
            quadro.GetComponent<QuadroDesafiosControlador>().Destrancar();
        }
    }

}
