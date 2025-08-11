using System.Collections;
using UnityEngine;

public class Irrigacao : MonoBehaviour
{
    public int contagem;

    public GameObject vasilhaComAgua; // Vasilha com �gua
    public GameObject irrigacaoParticula; // Part�culas de irriga��o
    public GameObject Vapor; // Part�culas de vapor

    // Game objects com as anima��es para serem ativados
    public GameObject[] plantas;
    public GameObject lampada;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            yield return new WaitForSeconds(8f);
            Vapor.GetComponent<ParticleSystem>().Stop(); // Para as part�culas de vapor
            vasilhaComAgua.GetComponent<MeshRenderer>().materials[1].color = Color.blue; // Muda a cor do material da vasilha para azul (�gua)
            yield return new WaitForSeconds(10f);
            irrigacaoParticula.SetActive(false); // Desativa as part�culas de irriga��o
        }
    }
}
