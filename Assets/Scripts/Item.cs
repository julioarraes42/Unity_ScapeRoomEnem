using UnityEngine;

public class Item : MonoBehaviour
{
    public string nome;
    public string codigo;
    public Sprite icone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destruir()
    {
                Destroy(gameObject); // Destroi o objeto do jogo
    }
}
