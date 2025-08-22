using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteracoesUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 posicaoInicial;
    public string itemSegurado;
    public GameObject player;
    public GameObject simbolosControlador; // Referência ao GameObject que contém os símbolos de controle
    public Canvas canvas;

    // Referencia os audios de interação
    public AudioSource audioLargarItemErrado;
    public AudioSource audioSegurarItem;
    public AudioSource audioLargarItemCerto;

    // Referencia a particulas
    public GameObject particulasAcido; // Partículas para o ácido

    // Referencia a materiais
    public Material acido;

    // Referencia a controladores
    public GameObject animacaoControlador; // Controlador de animação
    public GameObject puzzleControlador; //controlador dos puzzles

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posicaoInicial = rectTransform.anchoredPosition; // Guarda a posição inicial do objeto
        itemSegurado = GetComponent<Slot>().nome; // Obtém o componente Item do objeto arrastado
        audioSegurarItem.Play(); // Toca o áudio de segurar item
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
                    audioLargarItemCerto.Play(); // Toca o áudio de sucesso ao largar o item no local correto
                    hit.collider.GetComponent<MeshRenderer>().enabled = true; // Ativa o renderizador do slot de célula
                    player.GetComponent<Inventario>().RemoverItem(itemSegurado); // Remove o item do inventário do jogador
                    puzzleControlador.GetComponent<PuzzleCelulaControlador>().AdicionarContagem(); // Adiciona à contagem do controlador do puzzle da célula
                }
            }
            else if (hit.collider.CompareTag("Forno"))
            {
                if (itemSegurado == "Agua")
                {
                    hit.collider.transform.Find("BequerCheio").GameObject().SetActive(true); // Ativa o bequer cheio no forno
                    player.GetComponent<Inventario>().RemoverItem(itemSegurado);
                    animacaoControlador.GetComponent<Irrigacao>().AdicionarItem(); // Aumenta a contagem do atributo Irrigação
                }
                else if (itemSegurado == "Nitrogenio" && (animacaoControlador.GetComponent<Irrigacao>().contagem >= 1))
                {
                    particulasAcido.GetComponent<ParticleSystem>().startLifetime = 12f;
                    particulasAcido.GetComponent<ParticleSystem>().startSpeed = 1f;

                    ParticleSystem particleSystem = particulasAcido.GetComponent<ParticleSystem>();
                    var emission = particleSystem.emission;
                    emission.rateOverTime = 30f; // Aumenta a taxa de emissão das partículas

                    player.GetComponent<Inventario>().RemoverItem(itemSegurado);
                    animacaoControlador.GetComponent<Irrigacao>().AdicionarItem(); // Aumenta a contagem do atributo Irrigação
                }
                else if (itemSegurado == "Enxofre" && (animacaoControlador.GetComponent<Irrigacao>().contagem >= 1))
                {
                    acido.SetColor("_BaseColor", Color.yellow); // Muda a cor do material para amarelo (enxofre)
                    player.GetComponent<Inventario>().RemoverItem(itemSegurado);
                    particulasAcido.GetComponent<ParticleSystem>().startColor = Color.yellow; // Define a cor das partículas para amarelo
                    animacaoControlador.GetComponent<Irrigacao>().AdicionarItem(); // Aumenta a contagem do atributo Irrigação
                }

                if (animacaoControlador.GetComponent<Irrigacao>().contagem == 3)
                {
                    animacaoControlador.GetComponent<Irrigacao>().Inicio(); // Inicia a animação de irrigação se a contagem for 3
                    puzzleControlador.GetComponent<PuzzleCelulaControlador>().AbrirQuadro3(); // Abre o terceiro quadro do puzzle
                }
            }
            else if (hit.collider.CompareTag("Quadro"))
            {
                if (itemSegurado == "ChaveDeFenda")
                {
                    animacaoControlador.GetComponent<TirarQuadroControlador>().iniciarAnimacao();
                    player.GetComponent<Inventario>().RemoverItem(itemSegurado); // Remove o item do inventário do jogador
                }
                else
                {
                    audioLargarItemErrado.Play(); // Toca o áudio de erro ao largar o item em local errado
                }
            }
            else
            {
                audioLargarItemErrado.Play(); // Toca o áudio de erro ao largar o item em local errado
            }
        }

        rectTransform.anchoredPosition = posicaoInicial; // Retorna o objeto para a posição inicial após o arrasto
        player.GetComponent<Inventario>().AtualizarInventario(); // Atualiza o inventário do jogador após o arrasto
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
