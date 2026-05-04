using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puzzle5Controler : MonoBehaviour
{
    [SerializeField] private GameObject tela;
    [SerializeField] private GameObject[] IconesDesativados;
    [SerializeField] private GameObject[] IconesAtivados;
    [SerializeField] private PlayerComandos playerComandos;
    public bool ativo = false;

    [SerializeField] private int temperatura = 30;
    [SerializeField] private int temperaturaAtual = 30;
    [SerializeField] private bool emProcessamento = false;
    [SerializeField] private TMP_InputField valorDeTemperatura;
    [SerializeField] private TextMeshProUGUI valorTermometro;
    [SerializeField] private int valorMudado = 3;
    [SerializeField] private int intervaloDeMudança = 1;
    [SerializeField] private int heigtMax = 300;
    [SerializeField] private Image termometro;

    //Objetos para controlar os indicadores
    [SerializeField] private GameObject indicadorAumento;
    [SerializeField] private GameObject indicadorReducao;
    [SerializeField] private GameObject[] indicadoresObjetivo;
    private int[] valoresIndicadores = { 95, 55, 72 };
    [SerializeField] private int ordemIndicador = 0;
 

    private void Start()
    {
        valorTermometro.color = Color.gray;

        indicadorReducao.SetActive(false);
        indicadorAumento.SetActive(false);
    }

    private void Update()
    {
        if (ativo)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ativar();
            }
        }

        valorTermometro.text = temperaturaAtual.ToString();

        termometro.rectTransform.localScale = new Vector2(termometro.rectTransform.localScale.x, temperaturaAtual);

    }

    private void Processo()
    {
        if (temperaturaAtual != temperatura)
        {
            if (temperaturaAtual < temperatura)
            {
                indicadorAumento.SetActive(true);
                valorTermometro.color = Color.red;

                if ((temperatura - temperaturaAtual) <= valorMudado)
                {
                    temperaturaAtual = temperatura;
                }
                else
                {
                    temperaturaAtual += valorMudado;
                }
            } else
            {

                indicadorReducao.SetActive(true);
                valorTermometro.color = Color.blue;


                if ((temperaturaAtual - temperatura) <= valorMudado)
                {
                    temperaturaAtual = temperatura;
                }
                else
                {
                    temperaturaAtual -= valorMudado;
                }
            }

        } else
        {
            indicadorReducao.SetActive(false);
            indicadorAumento.SetActive(false);
            valorTermometro.color = Color.gray;

            if(temperaturaAtual == valoresIndicadores[ordemIndicador])
            {
                indicadoresObjetivo[ordemIndicador].SetActive(true);
                ordemIndicador++;
            }
            else
            {
                for(int i = 0; i < indicadoresObjetivo.Length; i++)
                {
                    indicadoresObjetivo[i].SetActive(false);
                }
                ordemIndicador = 0;
            }

            if(ordemIndicador == 3)
            {
                Debug.Log("Concluido a primeira etapa");
            }

            CancelInvoke("Processo");
        }
    }

    public void botaoAtivacao()
    {
        Debug.Log("/"+ valorDeTemperatura.text+ "/");

        temperatura = int.Parse(valorDeTemperatura.text);

        InvokeRepeating("Processo", intervaloDeMudança, intervaloDeMudança);
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
