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
    public bool menuAberto = false; // Vari�vel para controlar o estado do menu

    // Refer�ncia a GameObjects que cont�m a UI
    public GameObject comandoPegarUI;
    public GameObject mira;
    public GameObject comandoInventarioUI;
    public GameObject painelTextoNome;
    public GameObject textoNome;
    public GameObject descricaoParteCelula;
    public GameObject comandoInspecionarUI;
    public GameObject comandoSairInspecaoUI;
    public GameObject telaSenhaUI; // Refer�ncia � UI de tela de senha

    // Referencia aos Audio Sources
    public AudioSource audioSourcePegarItem; // Fonte de �udio para pegar item
    public AudioSource audioSourceInventario; // Fonte de �udio para abrir invent�rio

    // Referencia ao computador para a a��o de inspecionalo
    public GameObject computador; // Refer�ncia ao computador para intera��o
    private bool inspecionandoComputador = false; // Vari�vel para controlar se est� inspecionando o computador
    private Vector3 cameraPosicao; // Refer�ncia � posi��o da c�mera para inspe��o

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
        controler = GetComponent<CharacterController>(); // Obt�m o componente CharacterController do jogador
        inventario = GetComponent<Inventario>(); // Obt�m o componente Inventario do jogador
        comandoSairInspecaoUI.SetActive(false); // Desativa a UI de comando de sair da inspe��o inicialmente
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
            rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f); // Limita a rota��o vertical
            mainCamera.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX); // Rota��o horizontal do jogador

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 movimento = transform.right * x + transform.forward * z; // Movimento baseado na dire��o do jogador

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
                comandoPegarUI.SetActive(false); // Desativa a UI de comando de pegar item se n�o estiver sobre um item
                painelTextoNome.SetActive(false); // Desativa o painel de texto do nome do item

            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Computador") && !comandoInspecionarUI.activeSelf && !inventarioAberto && !menuAberto)
            {
                comandoInspecionarUI.SetActive(true); // Ativa a UI de comando de inspecionar
            }
            else if ((!hit.collider.CompareTag("Computador") && comandoInspecionarUI.activeSelf) || menuAberto)
            {
                comandoInspecionarUI.SetActive(false); // Desativa a UI de comando de inspecionar se n�o estiver sobre um slot de c�lula
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("SlotCelula") && !inventarioAberto)
            {
                
            }
            else if (!hit.collider.CompareTag("SlotCelula") && comandoPegarUI.activeSelf)
            {
                
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !inventarioAberto)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    inventario.AdicionarItem(hit.collider.GetComponent<Item>()); // Adiciona o item ao invent�rio
                    audioSourcePegarItem.Play(); // Toca o som de pegar item
                }
                else if (hit.collider.CompareTag("InteracaoAnimada"))
                {
                    hit.collider.GetComponent<Porta>().Interacao(); // Chama o m�todo de intera��o da porta
                }
                else if (hit.collider.CompareTag("Computador"))
                {
                    InspecionarComputador(); // Chama o m�todo para inspecionar o computador
                }else if (hit.collider.CompareTag("LeitorSenha"))
                {
                    telaSenhaUI.SetActive(true);
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioSourceInventario.Play(); // Toca o som de abrir invent�rio

            if (inventarioAberto)
            {
                // Se o invent�rio j� estiver aberto, fecha-o
                inventario.AbrirInventario();
                Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
                inventarioAberto = false; // Marca o invent�rio como fechado
                mira.SetActive(true); // Ativa a mira quando o invent�rio � fechado
                comandoInventarioUI.SetActive(true);
            }
            else
            {
                // Se o invent�rio n�o estiver aberto, abre-o
                inventario.AbrirInventario();
                Cursor.lockState = CursorLockMode.None; // Libera o cursor
                inventarioAberto = true; // Marca o invent�rio como aberto
                mira.SetActive(false);
                comandoInventarioUI.SetActive(false);
            }
        }

    }

    public void InspecionarComputador()
    {
        if (computador != null)
        {
            if(!inspecionandoComputador)
            {
                // Se n�o est� inspecionando, inicia a inspe��o
                comandoInventarioUI.SetActive(false); // Desativa o comando de invent�rio
                mira.SetActive(false); // Desativa a mira
                comandoSairInspecaoUI.SetActive(true); // Ativa o comando de sair da inspe��o
                cameraPosicao = mainCamera.transform.position; // Armazena a posi��o atual da c�mera
                inspecionandoComputador = true;
                mainCamera.position = computador.transform.position + new Vector3(0, 0.65f, -1f); // Posiciona a c�mera na frente do computador
                mainCamera.rotation = Quaternion.Euler(0, 0, 0); // Reseta a rota��o da c�mera
                Cursor.lockState = CursorLockMode.None; // Libera o cursor
                menuAberto = true; // Marca o menu como aberto
            }
            else
            {
                // Se j� est� inspecionando, fecha a inspe��o
                inspecionandoComputador = false;
                Cursor.lockState = CursorLockMode.Locked; // Trava o cursor novamente
                menuAberto = false; // Marca o menu como fechado
                mainCamera.position = cameraPosicao; // Restaura a posi��o original da c�mera
                comandoInventarioUI.SetActive(true); // Reativa o comando de invent�rio
                mira.SetActive(true); // Reativa a mira
                comandoSairInspecaoUI.SetActive(false); // Desativa o comando de sair da inspe��o
            }
        }
    }
}
