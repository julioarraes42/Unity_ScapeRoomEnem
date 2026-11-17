using UnityEngine;

public class ClonarDNA : MonoBehaviour
{
    public GameObject tela;
    public bool telaAtiva = false;
    public PlayerComandos playerComandos;
    public GameObject[] iconesDesativos;
    public GameObject[] iconesAtivos;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (telaAtiva)
            {
                DesativarTela();
            }
        }
    }

    public void AtivarTela()
    {
        Cursor.lockState = CursorLockMode.None;
        playerComandos.menuAberto = true;
        telaAtiva = !telaAtiva;
        tela.SetActive(telaAtiva);

        for (int i = 0; i < iconesDesativos.Length; i++)
        {
            iconesDesativos[i].SetActive(!telaAtiva);
        }

        for (int i = 0; i < iconesAtivos.Length; i++)
        {
            iconesAtivos[i].SetActive(telaAtiva);
        }
    }

    public void DesativarTela()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerComandos.menuAberto = false;
        telaAtiva = false;
        tela.SetActive(telaAtiva);

        for (int i = 0; i < iconesDesativos.Length; i++)
        {
            iconesDesativos[i].SetActive(!telaAtiva);
        }

        for (int i = 0; i < iconesAtivos.Length; i++)
        {
            iconesAtivos[i].SetActive(telaAtiva);
        }
    }
}
