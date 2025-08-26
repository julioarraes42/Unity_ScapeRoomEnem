using UnityEngine;

public class PortaFinalControlador : MonoBehaviour
{
    public GameObject porta;

    public void Abrir()
    {
        porta.GetComponent<Animator>().SetTrigger("Ativar");
    }
}
