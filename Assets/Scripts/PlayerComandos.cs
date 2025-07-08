using UnityEngine;

public class PlayerComandos : MonoBehaviour
{
    public float velocidade = 5f;
    public float sensibilidade = 100f;
    public Transform mainCamera;

    public Inventario inventario;
    private CharacterController controler;
    float rotacaoX = 0f;
    private bool inventarioAberto = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
        controler = GetComponent<CharacterController>(); // Obtém o componente CharacterController do jogador
        inventario = GetComponent<Inventario>(); // Obtém o componente Inventario do jogador
    }
    void Update()
    {
        if (!inventarioAberto)
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


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    inventario.AdicionarItem(hit.collider.GetComponent<Item>()); // Adiciona o item ao inventário
                }

            }


        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventarioAberto)
            {
                inventario.AbrirInventario();
                Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
                inventarioAberto = false; // Marca o inventário como fechado
            }
            else
            {
                inventario.AbrirInventario();
                Cursor.lockState = CursorLockMode.None; // Libera o cursor
                inventarioAberto = true; // Marca o inventário como aberto
            }
        }

    }
}
