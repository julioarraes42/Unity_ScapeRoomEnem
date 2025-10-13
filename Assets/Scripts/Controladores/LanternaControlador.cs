using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LanternaControlador : MonoBehaviour
{
    public GameObject lanterna; // Referência ao componente SpotLight da lanterna
    public AudioSource audio; // Referência ao componente AudioSource para o som da lanterna
    public PlayerComandos playerComandos; // Referência ao script PlayerComandos para verificar o estado do menu

    void Update()
    {

        // Verificar se a tecla "F" foi pressionada
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerComandos.menuAberto || playerComandos.inventarioAberto)
            {
                return;
            }
            // Alternar o estado da lanterna
            lanterna.SetActive(!lanterna.activeSelf);
            // Tocar o som da lanterna
            audio.Play();
        }
    }
}
