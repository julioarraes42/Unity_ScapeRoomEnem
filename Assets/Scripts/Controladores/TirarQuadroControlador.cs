using UnityEngine;

public class TirarQuadroControlador : MonoBehaviour
{
    public GameObject quadro;
    public GameObject chaveDeFenda;

    public void iniciarAnimacao()
    {
        chaveDeFenda.SetActive(true);
        quadro.GetComponent<Animator>().SetTrigger("TirarQuadro");
    }
}
