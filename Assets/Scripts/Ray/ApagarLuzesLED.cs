using System.Collections.Generic;
using UnityEngine;

public class ApagarLuzesLED : MonoBehaviour
{
    public Material led;
    public List<Light> luzes;
    public void Interrupitor(){
       bool algumaEstavaLigada = false;

        foreach (Light light in luzes)
        {
            if (light.enabled)
            {
                light.enabled = false;
                algumaEstavaLigada = true;
            }
            else
            {
                light.enabled = true;
            }
        }

        // Se alguma estava ligada, desliga a emissão
        if (algumaEstavaLigada)
        {
            led.DisableKeyword("_EMISSION");
            led.SetColor("_EmissionColor", Color.black);
        }
        else
        {
            led.EnableKeyword("_EMISSION");
            led.SetColor("_EmissionColor", Color.white); // Ou outra cor que simule o LED ligado
        }
    }
}
