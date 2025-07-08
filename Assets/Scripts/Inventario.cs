using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<Item> items; // Lista de objetos no inventario
    public List<string> nome; // Lista de nomes dos objetos no inventario apenas para fins de teste
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) //Si precionar a tecla "I"
        {
            AbrirInventario(); // Mostrar o inventario
        }
    }

    public void AbrirInventario()
    {
        Debug.Log("Inventário aberto!");
    }

    public void AdicionarItem(Item item)
    {
        if (item != null && !items.Contains(item))
        {
            items.Add(item);
            nome.Add(item.nome); // Adiciona o nome do item à lista de nomes para fins de teste
            item.destruir(); // Destroi o objeto do jogo após adicioná-lo ao inventário
            Debug.Log($"Item {item.nome} adicionado ao inventário.");
        }
        else
        {
            Debug.LogWarning("Item inválido ou já está no inventário.");
        }
    }
}
