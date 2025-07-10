using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteracoesUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 posicaoInicial;
    public string itemSegurado;
    public GameObject player;

    public Canvas canvas;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posicaoInicial = rectTransform.anchoredPosition; // Guarda a posi��o inicial do objeto
        itemSegurado = GetComponent<Slot>().nome; // Obt�m o componente Item do objeto arrastado
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
                    hit.collider.GetComponent<MeshRenderer>().enabled = true; // Ativa o renderizador do slot de c�lula
                    player.GetComponent<Inventario>().RemoverItem(itemSegurado); // Remove o item do invent�rio do jogador
                }
            }
            else
            {
                Debug.Log("Deu Errado");
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
