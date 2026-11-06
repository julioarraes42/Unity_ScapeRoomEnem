using UnityEngine;

public class Microscopio : MonoBehaviour
{
    public GameObject tela;
    public GameObject iconeSair;
    public PlayerComandos playerComandos;
    private bool telaAberta = false;

    public void AbrirTela()
    {
        telaAberta = true;
        tela.SetActive(true);
        iconeSair.SetActive(true);
        playerComandos.inventarioAberto = true;
    }

    public void FecharTela()
    {
        telaAberta = false;
        tela.SetActive(false);
        iconeSair.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerComandos.inventarioAberto = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && telaAberta)
        {
            FecharTela();
        }
    }
}
