using UnityEngine;

public class ComputadorControler : MonoBehaviour
{
    public GameObject telaSenha;
    public GameObject telaImagem;

    public void VerificarResultado()
    {
        if(GetComponent<SenhaControlador>().Verificar())
        {
            telaSenha.SetActive(false);
            telaImagem.SetActive(true);
        }
    }
}
