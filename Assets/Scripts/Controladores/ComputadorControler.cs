using System.Collections;
using UnityEngine;

public class ComputadorControler : MonoBehaviour
{
    public GameObject telaSenha;
    public GameObject telaImagem;
    public GameObject telaErro;

    public GameObject puzzleControlador; // Referência ao controlador do puzzle

    public void VerificarResultado()
    {
        if(GetComponent<SenhaControlador>().Verificar())
        {
            telaSenha.SetActive(false);
            telaImagem.SetActive(true);
            puzzleControlador.GetComponent<PuzzleCelulaControlador>().AbrirQuadro2();
        }
        else
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
