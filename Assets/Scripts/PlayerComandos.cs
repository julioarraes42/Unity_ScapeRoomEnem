using UnityEngine;

public class PlayerComandos : MonoBehaviour
{
    public float velocidade = 5f;
    public float sensibilidade = 100f;
    public Transform mainCamera;
    public Transform inventario;

    private bool inventarioAberto;
    private CharacterController controler;
    float rotacaoX = 0f;

    void Start()
    {
        inventario.gameObject.SetActive(false);
        inventarioAberto = false;
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
        controler = GetComponent<CharacterController>(); // Obt�m o componente CharacterController do jogador
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

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("Item"))
                {
                    hit.collider.GetComponent<InventarioControlador>().AdicionarItemAoInventario();
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventario.gameObject.SetActive(!inventario.gameObject.activeSelf); // Alterna a visibilidade do invent�rio
            inventarioAberto = !inventarioAberto; // Atualiza o estado do invent�rio
            Cursor.lockState = inventario.gameObject.activeSelf ? CursorLockMode.None : CursorLockMode.Locked; // Desbloqueia o cursor se o invent�rio estiver aberto
        }

    }
}
