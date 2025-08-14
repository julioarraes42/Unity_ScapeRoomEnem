using System.Collections;
using UnityEngine;

public class Irrigacao : MonoBehaviour
{
    public int contagem;

    public Material Agua; // Vasilha com água
    public GameObject irrigacaoParticula; // Partículas de irrigação
    public GameObject Vapor; // Partículas de vapor

    // Game objects com as animações para serem ativados
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
        StartCoroutine(Esperar(1)); // Inicia a coroutine para esperar 10 segundos antes de ativar as plantas e a irrigação
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

        StartCoroutine(Esperar(2)); // Inicia a coroutine para esperar e ativar as partículas de irrigação


    }

    IEnumerator Esperar(int etapa)
    {
        if (etapa == 1)
        {
            yield return new WaitForSeconds(10f); // Espera 10 segundos
            Descontaminacao(); // Chama o método de descontaminação
        }
        else if (etapa == 2)
        {
            yield return new WaitForSeconds(2f); // Espera 2 segundos
            irrigacaoParticula.SetActive(true); // Ativa as partículas de irrigação
            for (int i = 0; i < plantasInvisiveis.Length; i++)
            {
                if (plantasInvisiveis[i] != null)
                {
                    plantasInvisiveis[i].GetComponent<MeshRenderer>().enabled = true; // Torna as plantas invisíveis visíveis
                }
            }
            yield return new WaitForSeconds(8f);
            Vapor.GetComponent<ParticleSystem>().Stop(); // Para as partículas de vapor
            Agua.SetColor("_BaseColor", Color.blue); // Reseta a cor da água para azul
            yield return new WaitForSeconds(10f);
            irrigacaoParticula.SetActive(false); // Desativa as partículas de irrigação
        }
    }
}
