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
                    simbolosControlador.GetComponent<QuadroSimbolosControler>().adicionarNumeroCelula(); // Adiciona número de célula no controlador de símbolos
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
