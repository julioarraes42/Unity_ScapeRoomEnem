using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LanternaControlador : MonoBehaviour
{
    public GameObject lanterna; // Referência ao componente SpotLight da lanterna
    void Update()
    {

        // Verificar se a tecla "F" foi pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Alternar o estado da lanterna
            lanterna.SetActive(!lanterna.activeSelf);
        }
    }
}
