using UnityEngine;

public class Puzzle6Controler : MonoBehaviour
{
    [SerializeField] private GameObject tela;
    [SerializeField] private GameObject[] IconesDesativados;
    [SerializeField] private GameObject[] IconesAtivados;
    [SerializeField] private PlayerComandos playerComandos;
    public bool ativo = false;


    private void Update()
    {
        if (ativo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ativar();
            }
        }
    }

    public void ativar()
    {

        if (!ativo)
        {
            tela.SetActive(true);

            for (int i = 0; i < IconesDesativados.Length; i++)
            {
                IconesDesativados[i].SetActive(false);
            }

            for (int i = 0; i < IconesAtivados.Length; i++)
            {
                IconesAtivados[i].SetActive(true);
            }

            playerComandos.menuAberto = true;

            Cursor.lockState = CursorLockMode.None;

            ativo = true;
        }
        else
        {
            tela.SetActive(false);

            for (int i = 0; i < IconesDesativados.Length; i++)
            {
                IconesDesativados[i].SetActive(true);
            }

            for (int i = 0; i < IconesAtivados.Length; i++)
            {
                IconesAtivados[i].SetActive(false);
            }

            playerComandos.menuAberto = false;

            Cursor.lockState = CursorLockMode.Locked;

            ativo = false;
        }
    }

}
