using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteracoesUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 posicaoInicial;
    public string itemSegurado;

    public Canvas canvas;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posicaoInicial = rectTransform.anchoredPosition; // Guarda a posição inicial do objeto
        itemSegurado = GetComponent<Slot>().nome; // Obtém o componente Item do objeto arrastado
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
            }else if (hit.collider.CompareTag("SlotCelula"))
            {
                if (hit.collider.GetComponent<SlotCelula>().nome == itemSegurado)
                {
                    Debug.Log("Deu SUPER Certo");
                }
            }
            else
            {
                Debug.Log("Deu Errado");
            }
        }

        rectTransform.anchoredPosition = posicaoInicial; // Retorna o objeto para a posição inicial após o arrasto
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
