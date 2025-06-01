using UnityEngine;

public class Interação : MonoBehaviour
{
    private RaycastHit raycastHit;
    private Ray ray;
    void Start()
    {
        
    }
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        Vector3 centroTela = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        
        ray = Camera.main.ScreenPointToRay(centroTela);

        if (Physics.Raycast(ray, out raycastHit, 100f)) // 100f é o alcance máximo
        {
            Debug.Log("Acertou: " + raycastHit.collider.name);
        }

        ApagarLuzesLED apagarLuzesLED = this.raycastHit.collider.GetComponent<ApagarLuzesLED>();

        if (apagarLuzesLED){
            apagarLuzesLED.Interrupitor();
        }

    }
}
