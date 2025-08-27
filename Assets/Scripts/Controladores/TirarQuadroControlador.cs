using UnityEngine;

public class TirarQuadroControlador : MonoBehaviour
{
    public GameObject quadro;
    public GameObject chaveDeFenda;

    public void iniciarAnimacao()
    {
        chaveDeFenda.SetActive(true);
        quadro.GetComponent<BoxCollider>().enabled = false;
        quadro.GetComponent<Animator>().SetTrigger("TirarQuadro");
    }
}
