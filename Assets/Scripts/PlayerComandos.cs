using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComandos : MonoBehaviour
{
    public float velocidade = 5f;
    public float sensibilidade = 100f;
    public Transform mainCamera;

    public Inventario inventario;
    private CharacterController controler;
    float rotacaoX = 0f;
    public bool inventarioAberto = false;
    public bool menuAberto = false; // Variável para controlar o estado do menu

    // Referência a GameObjects que contém a UI
    public GameObject comandoPegarUI;
    public GameObject mira;
    public GameObject comandoInventarioUI;
    public GameObject painelTextoNome;
    public GameObject textoNome;

    // Referencia aos Audio Sources
    public AudioSource audioSourcePegarItem; // Fonte de áudio para pegar item
    public AudioSource audioSourceInventario; // Fonte de áudio para abrir inventário

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
        controler = GetComponent<CharacterController>(); // Obtém o componente CharacterController do jogador
        inventario = GetComponent<Inventario>(); // Obtém o componente Inventario do jogador
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!(inventarioAberto || menuAberto))
        {
            float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;

            rotacaoX -= mouseY;
            rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f); // Limita a rotação vertical
            mainCamera.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX); // Rotação horizontal do jogador

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 movimento = transform.right * x + transform.forward * z; // Movimento baseado na direção do jogador

            controler.Move(movimento * velocidade * Time.deltaTime); // Move o jogador com base no input e velocidade
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Item") && !comandoPegarUI.activeSelf && !inventarioAberto)
            {
                comandoPegarUI.SetActive(true); // Ativa a UI de comando de pegar item
                textoNome.GetComponent<TextMeshProUGUI>().text = hit.collider.GetComponent<Item>().nome; // Atualiza o texto com o nome do item
                painelTextoNome.SetActive(true); // Ativa o painel de texto do nome do item

            }
            else if (!hit.collider.CompareTag("Item") && comandoPegarUI.activeSelf)
            {
                comandoPegarUI.SetActive(false); // Desativa a UI de comando de pegar item se não estiver sobre um item
                painelTextoNome.SetActive(false); // Desativa o painel de texto do nome do item

            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !inventarioAberto)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    inventario.AdicionarItem(hit.collider.GetComponent<Item>()); // Adiciona o item ao inventário
                    audioSourcePegarItem.Play(); // Toca o som de pegar item
                }

            }


        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioSourceInventario.Play(); // Toca o som de abrir inventário

            if (inventarioAberto)
            {
                // Se o inventário já estiver aberto, fecha-o
                inventario.AbrirInventario();
                Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
                inventarioAberto = false; // Marca o inventário como fechado
                mira.SetActive(true); // Ativa a mira quando o inventário é fechado
                comandoInventarioUI.SetActive(true);
            }
            else
            {
                // Se o inventário não estiver aberto, abre-o
                inventario.AbrirInventario();
                Cursor.lockState = CursorLockMode.None; // Libera o cursor
                inventarioAberto = true; // Marca o inventário como aberto
                mira.SetActive(false);
                comandoInventarioUI.SetActive(false);
            }
        }

    }
}
