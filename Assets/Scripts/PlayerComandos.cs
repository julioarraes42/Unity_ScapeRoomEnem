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
        controler = GetComponent<CharacterController>(); // Obt�m o componente CharacterController do jogador
        inventario = GetComponent<Inventario>(); // Obt�m o componente Inventario do jogador
    }
    void Update()
    {
        if (!inventarioAberto)
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


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    inventario.AdicionarItem(hit.collider.GetComponent<Item>()); // Adiciona o item ao invent�rio
                }

            }


        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventarioAberto)
            {
                inventario.AbrirInventario();
                Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
                inventarioAberto = false; // Marca o invent�rio como fechado
            }
            else
            {
                inventario.AbrirInventario();
                Cursor.lockState = CursorLockMode.None; // Libera o cursor
                inventarioAberto = true; // Marca o invent�rio como aberto
            }
        }

    }
}
