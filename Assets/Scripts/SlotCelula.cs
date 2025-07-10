using UnityEngine;

public class SlotCelula : MonoBehaviour
{
    public string nome;

    public void Start()
    {
        GetComponent<MeshRenderer>().enabled = false; // Desativa o renderizador do slot de célula
    }
}
