using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour,IActivatable
{
    Light2D light2D;
    LightControl lightc;
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        lightc = GetComponent<LightControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOn()
    {
        if (light2D != null)
        {
            light2D.enabled = true;
            

        }
        if(lightc != null)
        {
            lightc.enabled = true;
        }
    }
    public void TurnOff()
    {
        light2D.enabled = false;
        if (lightc != null)
        {
            lightc.enabled = false;
        }
    }
}
