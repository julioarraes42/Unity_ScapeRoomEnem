using TMPro;
using UnityEngine;

public class PuzzleAnatomiaControler : MonoBehaviour
{
    [SerializeField] private GameObject[] orgaos;
    [SerializeField] private GameObject[] orgaosItens;
    [SerializeField] private string[] textosPedidos;
    [SerializeField] private string[] textosPadroes;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private PuzzleCelulaControlador quadroControlador;
    [SerializeField] private Transform[] orgaosPosicao;
    [SerializeField] private GameObject balaoConversa;
    [SerializeField]private string[] nomeOrgaos = { "coracao", "figado", "estomago", "pulmao", "intestino" };
    private string[] nomeOrgaosSave = { "coracao", "figado", "estomago", "pulmao", "intestino" };
    private string orgaoPedido;
    public bool interagivel = true;
    private int sequencia = 0;

    private void Start()
    {
        orgaosPosicao = new Transform[5];

        for (int i = 0; i < orgaos.Length; i++)
        {
            orgaosPosicao[i] = orgaos[i].transform;
        }
    }

    public bool AdicionarOrgao(string nome)
    {
        if (nome == orgaoPedido)
        {
            sequencia++;

            interagivel = true;

            for (int i = 0; i < nomeOrgaos.Length; i++)
            {
                if (nomeOrgaos[i] == nome)
                {
                    orgaos[i].SetActive(true);
                    nomeOrgaos[i] = null;
                    Interacao();
                    return true;
                }
            }
            return false;
        }
        else
        {
            Resetar(nome);
            return false;
        }
    }

    public void Interacao()
    {
        Debug.Log("sequencia = " + sequencia);

        if (interagivel == true && sequencia <= 4 && balaoConversa.activeSelf) 
        {
            for (int i = 0; i < 1;)
            {
                int numero = Random.Range(0, 5);

                if (nomeOrgaos[numero] != null)
                {
                    orgaoPedido = nomeOrgaos[numero];
                    textMeshPro.text = textosPedidos[numero];
                    interagivel = false;
                    i++;
                }
            }
        }else if(!balaoConversa.activeSelf){
            balaoConversa.SetActive(true);
        }
        else
        {
            textMeshPro.text = "PARABENS VOCÊ CONSEGUIU!";
            quadroControlador.AbrirQuadro6();
            interagivel = false;
        }
    }

    public void Resetar(string item)
    {
        for (int i = 0; i < orgaosItens.Length; i++)
        {
            if (orgaosItens[i].GetComponent<Item>().nome == item)
            {
                orgaosItens[i].SetActive(true);
            }
        }
    }

}
