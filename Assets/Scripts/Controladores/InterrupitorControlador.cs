using UnityEngine;

public class InterrupitorControlador : MonoBehaviour
{
    public GameObject[] luzes;
    public GameObject[] luzesSimbolos;
    public bool interruptorAtivado = true;
    public GameObject x;

    public void Ativar()
    {
        interruptorAtivado = !interruptorAtivado;

        // Ativa todas as luzes
        foreach (GameObject luz in luzes)
        {
            luz.SetActive(!luz.activeSelf);
            if (x != null) {
                x.SetActive(!x.activeSelf);
            }
        }

        // Ativa todos os símbolos
        foreach (GameObject simbolo in luzesSimbolos)
        {
            simbolo.SetActive(!interruptorAtivado);
        }

        //Rotaciona o objeto em 180 graus no eixo Y
        transform.Rotate(0f, 180f, 0f);
    }
}
