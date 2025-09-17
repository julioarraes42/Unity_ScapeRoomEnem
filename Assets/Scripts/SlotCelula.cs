using UnityEngine;

public class SlotCelula : MonoBehaviour
{
    public string nome;
    public GameObject dicaBanner; // Referência ao banner de dica

    public void Start()
    {
        GetComponent<MeshRenderer>().enabled = false; // Desativa o renderizador do slot de célula
    }
}
