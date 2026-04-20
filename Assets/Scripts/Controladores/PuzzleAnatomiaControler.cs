using TMPro;
using UnityEngine;

public class PuzzleAnatomiaControler : MonoBehaviour
{
    [SerializeField] private GameObject[] orgaos;
    [SerializeField] private string[] textosPedidos;
    [SerializeField] private string[] textosPadroes;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    private string[] nomeOrgaos = { "coracao", "figado", "estomago", "pulmao", "intestino" };
    private string orgaoPedido;
    private bool interagivel = true;
    private int sequencia = 0;

    public bool AdicionarOrgao(string nome)
    {
        if (nome == orgaoPedido)
        {
            sequencia++;

            interagivel = true;

            int numero = Random.Range(0, 2);

            textMeshPro.text = textosPadroes[numero];

            if (nome == null)
            {
                return false;
            }
            else if (nome == "coracao")
            {
                orgaos[0].SetActive(true);
                nomeOrgaos[0] = null;
                return true;
            }
            else if (nome == "figado")
            {
                orgaos[1].SetActive(true);
                nomeOrgaos[1] = null;
                return true;
            }
            else if (nome == "estomago")
            {
                orgaos[2].SetActive(true);
                nomeOrgaos[2] = null;
                return true;
            }
            else if (nome == "pulmao")
            {
                orgaos[3].SetActive(true);
                nomeOrgaos[3] = null;
                return true;
            }
            else if (nome == "intestino")
            {
                orgaos[4].SetActive(true);
                nomeOrgaos[4] = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        else return false;
    }

    public void Interacao()
    {

        if (interagivel == true && sequencia <= 4) 
        {
            for (int i = 0; i < 1;)
            {
                int numero = Random.Range(0, 4);

                if (nomeOrgaos[numero] != null)
                {
                    orgaoPedido = nomeOrgaos[numero];
                    textMeshPro.text = textosPedidos[numero];
                    interagivel = false;
                    i++;
                }
            }
        }else
        {

        }
    }
}
