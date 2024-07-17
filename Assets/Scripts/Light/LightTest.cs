using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest : MonoBehaviour,ILightable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLight()
    {
        Debug.Log("Shining");
    }

    public void LoseLight()
    {
        Debug.Log("Not Shining");
    }
}
