using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<Item> items; // Lista de objetos no inventario
    public GameObject inventarioUI; // Referência ao painel do inventário na interface do usuário
    public Image[] iconesSlots; // Referência aos ícones dos slots do inventário na interface do usuário
    void Start()
    {
        inventarioUI.SetActive(false); // Inicialmente, o inventário está fechado
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void AbrirInventario()
    {
        inventarioUI.SetActive(!inventarioUI.activeSelf); // Alterna a visibilidade do painel do inventário
        Debug.Log("Inventário aberto!");
    }

    public void AdicionarItem(Item item)
    {
        if (item != null && !items.Contains(item))
        {
            items.Add(item);
            item.destruir(); // Destroi o objeto do jogo após adicioná-lo ao inventário
            Debug.Log($"Item {item.nome} adicionado ao inventário.");
            iconesSlots[items.Count - 1].sprite = item.icone; // Atualiza o ícone do slot correspondente no inventário
            iconesSlots[items.Count - 1].color = Color.white; // Define a cor do ícone para visível
        }
        else
        {
            Debug.LogWarning("Item inválido ou já está no inventário.");
        }
    }
}
