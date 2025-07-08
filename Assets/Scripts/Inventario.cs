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
        }
        else
        {
            Debug.LogWarning("Item inv�lido ou j� est� no invent�rio.");
        }
    }
}
