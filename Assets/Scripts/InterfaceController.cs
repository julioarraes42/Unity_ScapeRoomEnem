using UnityEngine;

public class InterfaceController : MonoBehaviour
{

    public GameObject InventoryPainel;

    bool inventoryOpen = false;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryOpen = !inventoryOpen;
            InventoryPainel.SetActive(inventoryOpen);
        }
        if(inventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
