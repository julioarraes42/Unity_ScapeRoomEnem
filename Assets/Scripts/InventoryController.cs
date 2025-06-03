using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public InventoryObjets[] Slots;
    public Image[] ImageSlots;
    public int[] SlotAmount;

   void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2));
        if (Physics.Raycast(ray, out hit, 5f)) 
        {
            if (hit.collider.tag == "Object")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    for (int i = 0; i < Slots.Length; i++)
                    {
                        if (Slots[i] != null || Slots[i].name == hit.transform.GetComponent<ObjectType>().objectType.name)
                        {
                            Slots[i] = hit.transform.GetComponent<ObjectType>().objectType;
                            SlotAmount[i]++;
                            ImageSlots[i].sprite = Slots[i].ItemSprite;

                            Destroy(hit.transform.gameObject);
                            break;
                        }
                    }
                }
            }
        }

        
    }

}
