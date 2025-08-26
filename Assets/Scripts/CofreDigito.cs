using UnityEngine;
using UnityEngine.UI;

public class CofreDigito : MonoBehaviour
{
    public Texture2D[] imagens;
    public GameObject digito;
    public int numero = 0;

    public void Iniciar()
    {
        digito.GetComponent<RawImage>().texture = imagens[numero];
    }

    public void Adicionar()
    {
        if (numero < (imagens.Length - 1))
        {
            numero++;
            digito.GetComponent<RawImage>().texture = imagens[numero];
        }

    }

    public void Remover()
    {
        if (numero >= 1)
        {
            numero--;
            digito.GetComponent<RawImage>().texture = imagens[numero];
        }
    }
}
