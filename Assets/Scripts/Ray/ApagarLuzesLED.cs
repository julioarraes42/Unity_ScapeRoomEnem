using System.Collections.Generic;
using UnityEngine;

public class ApagarLuzesLED : MonoBehaviour
{
    public Material led;
    public List<Light> luzes;
    public AudioSource som;
    public Light destaque;

    private void Start()
    {
        foreach (Light light in luzes)
        {
            light.enabled = false;
        }

        led.DisableKeyword("_EMISSION");
        led.SetColor("_EmissionColor", Color.black);

        destaque.enabled = true;
    }
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

        if (destaque.enabled)
        {
            destaque.enabled = false;
        }

        if (algumaEstavaLigada)
        {
            led.DisableKeyword("_EMISSION");
            led.SetColor("_EmissionColor", Color.black);
        }
        else
        {
            led.EnableKeyword("_EMISSION");
            led.SetColor("_EmissionColor", Color.white);
        }

        transform.Rotate(0f, 180f, 0f);
        som.Play();
    }
}
