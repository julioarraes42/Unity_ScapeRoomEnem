using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventarioControlador : MonoBehaviour
{
    public GameObject painel;
    public Sprite icone;
    void Start()
    {
        
    }

    public void AdicionarItemAoInventario()
    {
        {
            GameObject novoIcone = new GameObject("Icone");

            Image imagem = novoIcone.AddComponent<Image>();
            imagem.sprite = icone;

            novoIcone.transform.SetParent(painel.transform, false);

            Destroy(gameObject);

        }

    }
}
