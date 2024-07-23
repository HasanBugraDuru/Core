using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TurnGreen : MonoBehaviour,IActivatable
{
    Light2D light2D;
    LightControl light;
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
        light = GetComponent<LightControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnOn()
    {
        if (light2D != null)
        {
            light2D.color = Color.green;
            

        }
    }
    public void TurnOff()
    {
        light2D.color = Color.red;
        
    }
}
