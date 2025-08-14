using System.Collections;
using UnityEngine;

public class Irrigacao : MonoBehaviour
{
    public int contagem;

    public Material Agua; // Vasilha com �gua
    public GameObject irrigacaoParticula; // Part�culas de irriga��o
    public GameObject Vapor; // Part�culas de vapor

    // Game objects com as anima��es para serem ativados
    public GameObject[] plantas;
    public GameObject lampada;

    // Game objects para deixas as plantas invisiveis inicialmente
    public GameObject[] plantasInvisiveis;

    public void AdicionarItem()
    {
        contagem++;
    }

    public void Inicio()
    {
        StartCoroutine(Esperar(1)); // Inicia a coroutine para esperar 10 segundos antes de ativar as plantas e a irriga��o
    }

    public void Descontaminacao()
    {
        for (int i = 0; i < plantas.Length; i++)
        {
            if (plantas[i] != null)
            {
                plantas[i].SetActive(true); // Ativa a planta correspondente
                plantas[i].GetComponent<Animator>().SetTrigger("ativar");
            }
        }

        if (lampada != null)
        {
            lampada.GetComponent<Animator>().SetTrigger("ativar");
        }

        StartCoroutine(Esperar(2)); // Inicia a coroutine para esperar e ativar as part�culas de irriga��o


    }

    IEnumerator Esperar(int etapa)
    {
        if (etapa == 1)
        {
            yield return new WaitForSeconds(10f); // Espera 10 segundos
            Descontaminacao(); // Chama o m�todo de descontamina��o
        }
        else if (etapa == 2)
        {
            yield return new WaitForSeconds(2f); // Espera 2 segundos
            irrigacaoParticula.SetActive(true); // Ativa as part�culas de irriga��o
            for (int i = 0; i < plantasInvisiveis.Length; i++)
            {
                if (plantasInvisiveis[i] != null)
                {
                    plantasInvisiveis[i].GetComponent<MeshRenderer>().enabled = true; // Torna as plantas invis�veis vis�veis
                }
            }
            yield return new WaitForSeconds(8f);
            Vapor.GetComponent<ParticleSystem>().Stop(); // Para as part�culas de vapor
            Agua.SetColor("_BaseColor", Color.blue); // Reseta a cor da �gua para azul
            yield return new WaitForSeconds(10f);
            irrigacaoParticula.SetActive(false); // Desativa as part�culas de irriga��o
        }
    }
}
