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
            iconesSlots[items.Count - 1].GetComponent<Slot>().item = item; // Associa o item ao slot
            iconesSlots[items.Count - 1].GetComponent<Slot>().nome = item.nome; // Define o nome do item no slot
        }
        else
        {
            Debug.LogWarning("Item inválido ou já está no inventário.");
        }
    }

    public void RemoverItem(string nome)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].nome == nome)
            {
                Debug.Log($"Removendo item {items[i].nome} do inventário.");
                items.RemoveAt(i); // Remove o item da lista
                AtualizarInventario(); // Atualiza o inventário após a remoção
                return;
            }
        }
    }

    public void AtualizarInventario()
    {
        for (int i = 0; i < iconesSlots.Length; i++)
        {
            if (i < items.Count)
            {
                Debug.Log($"Atualizando slot {i} com o item {items[i].nome}.");
                iconesSlots[i].sprite = items[i].icone; // Atualiza o ícone do slot com o ícone do item
                iconesSlots[i].color = Color.white; // Define a cor do ícone para visível
                iconesSlots[i].GetComponent<Slot>().item = items[i]; // Associa o item ao slot
                iconesSlots[i].GetComponent<Slot>().nome = items[i].nome; // Define o nome do item no slot
            }
            else
            {
                Debug.Log($"Limpando slot {i}, pois não há item associado.");
                iconesSlots[i].sprite = null; // Limpa o ícone do slot se não houver item
                iconesSlots[i].color = new Color(0, 0, 0, 0); // Torna o ícone invisível
                iconesSlots[i].GetComponent<Slot>().item = null; // Remove a associação do item ao slot
                iconesSlots[i].GetComponent<Slot>().nome = ""; // Limpa o nome do item no slot
            }
        }
    }
}
