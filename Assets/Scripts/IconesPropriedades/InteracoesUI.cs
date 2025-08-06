using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteracoesUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 posicaoInicial;
    public string itemSegurado;
    public GameObject player;
    public GameObject simbolosControlador; // Refer�ncia ao GameObject que cont�m os s�mbolos de controle

    public Canvas canvas;

    // Referencia os audios de intera��o
    public AudioSource audioLargarItemErrado;
    public AudioSource audioSegurarItem;
    public AudioSource audioLargarItemCerto;

    // Referencia a particulas
    public GameObject particulasAcido; // Part�culas para o �cido

    // Referencia a materiais
    public Material acido;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posicaoInicial = rectTransform.anchoredPosition; // Guarda a posi��o inicial do objeto
        itemSegurado = GetComponent<Slot>().nome; // Obt�m o componente Item do objeto arrastado
        audioSegurarItem.Play(); // Toca o �udio de segurar item
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Drop"))
            {
                Debug.Log("Deu Certo");
            }
            else if (hit.collider.CompareTag("SlotCelula"))
            {
                if (hit.collider.GetComponent<SlotCelula>().nome == itemSegurado && !hit.collider.GetComponent<MeshRenderer>().enabled)
                {
                    audioLargarItemCerto.Play(); // Toca o �udio de sucesso ao largar o item no local correto
                    hit.collider.GetComponent<MeshRenderer>().enabled = true; // Ativa o renderizador do slot de c�lula
                    player.GetComponent<Inventario>().RemoverItem(itemSegurado); // Remove o item do invent�rio do jogador
                    simbolosControlador.GetComponent<QuadroSimbolosControler>().adicionarNumeroCelula(); // Adiciona n�mero de c�lula no controlador de s�mbolos
                }
            }
            else if (hit.collider.CompareTag("Forno"))
            {
                if (itemSegurado == "Agua")
                {
                    hit.collider.transform.Find("BequerCheio").GameObject().SetActive(true); // Ativa o bequer cheio no forno
                    player.GetComponent<Inventario>().RemoverItem(itemSegurado);
                }
                else if (itemSegurado == "Nitrogenio")
                {
                    particulasAcido.GetComponent<ParticleSystem>().startLifetime = 12f;
                    particulasAcido.GetComponent<ParticleSystem>().startSpeed = 1f;

                    ParticleSystem particleSystem = particulasAcido.GetComponent<ParticleSystem>();
                    var emission = particleSystem.emission;
                    emission.rateOverTime = 30f; // Aumenta a taxa de emiss�o das part�culas

                    player.GetComponent<Inventario>().RemoverItem(itemSegurado);
                }
                else if (itemSegurado == "Enxofre")
                {
                    acido.SetColor("_BaseColor", Color.yellow); // Muda a cor do material para amarelo (enxofre)
                    player.GetComponent<Inventario>().RemoverItem(itemSegurado);
                    particulasAcido.GetComponent<ParticleSystem>().startColor = Color.yellow; // Define a cor das part�culas para amarelo
                }
            }
            else
            {
                audioLargarItemErrado.Play(); // Toca o �udio de erro ao largar o item em local errado
            }
        }

        rectTransform.anchoredPosition = posicaoInicial; // Retorna o objeto para a posi��o inicial ap�s o arrasto
        player.GetComponent<Inventario>().AtualizarInventario(); // Atualiza o invent�rio do jogador ap�s o arrasto
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
