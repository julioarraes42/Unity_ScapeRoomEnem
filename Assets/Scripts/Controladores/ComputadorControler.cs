using System.Collections;
using UnityEngine;

public class ComputadorControler : MonoBehaviour
{
    public GameObject telaSenha;
    public GameObject telaImagem;
    public GameObject telaErro;

    public void VerificarResultado()
    {
        if(GetComponent<SenhaControlador>().Verificar())
        {
            telaSenha.SetActive(false);
            telaImagem.SetActive(true);
        }else
        {
            StartCoroutine(Esperar());
        }
    }

    IEnumerator Esperar()
    {
        telaErro.SetActive(true);
        yield return new WaitForSeconds(2f);
        telaErro.SetActive(false);
    }
}
