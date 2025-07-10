using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<Item> items; // Lista de objetos no inventario
    public GameObject inventarioUI; // Refer�ncia ao painel do invent�rio na interface do usu�rio
    public Image[] iconesSlots; // Refer�ncia aos �cones dos slots do invent�rio na interface do usu�rio
    void Start()
    {
        inventarioUI.SetActive(false); // Inicialmente, o invent�rio est� fechado
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void AbrirInventario()
    {
        inventarioUI.SetActive(!inventarioUI.activeSelf); // Alterna a visibilidade do painel do invent�rio
        Debug.Log("Invent�rio aberto!");
    }

    public void AdicionarItem(Item item)
    {
        if (item != null && !items.Contains(item))
        {
            items.Add(item);
            item.destruir(); // Destroi o objeto do jogo ap�s adicion�-lo ao invent�rio
            Debug.Log($"Item {item.nome} adicionado ao invent�rio.");
            iconesSlots[items.Count - 1].sprite = item.icone; // Atualiza o �cone do slot correspondente no invent�rio
            iconesSlots[items.Count - 1].color = Color.white; // Define a cor do �cone para vis�vel
            iconesSlots[items.Count - 1].GetComponent<Slot>().item = item; // Associa o item ao slot
            iconesSlots[items.Count - 1].GetComponent<Slot>().nome = item.nome; // Define o nome do item no slot
        }
        else
        {
            Debug.LogWarning("Item inv�lido ou j� est� no invent�rio.");
        }
    }

    public void RemoverItem(string nome)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].nome == nome)
            {
                Debug.Log($"Removendo item {items[i].nome} do invent�rio.");
                items.RemoveAt(i); // Remove o item da lista
                AtualizarInventario(); // Atualiza o invent�rio ap�s a remo��o
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
                iconesSlots[i].sprite = items[i].icone; // Atualiza o �cone do slot com o �cone do item
                iconesSlots[i].color = Color.white; // Define a cor do �cone para vis�vel
                iconesSlots[i].GetComponent<Slot>().item = items[i]; // Associa o item ao slot
                iconesSlots[i].GetComponent<Slot>().nome = items[i].nome; // Define o nome do item no slot
            }
            else
            {
                Debug.Log($"Limpando slot {i}, pois n�o h� item associado.");
                iconesSlots[i].sprite = null; // Limpa o �cone do slot se n�o houver item
                iconesSlots[i].color = new Color(0, 0, 0, 0); // Torna o �cone invis�vel
                iconesSlots[i].GetComponent<Slot>().item = null; // Remove a associa��o do item ao slot
                iconesSlots[i].GetComponent<Slot>().nome = ""; // Limpa o nome do item no slot
            }
        }
    }
}
