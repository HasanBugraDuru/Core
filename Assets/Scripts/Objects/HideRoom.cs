using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRoom : MonoBehaviour,IActivatable
{
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnOn()
    {
        gameObject.SetActive(false);
    }
    public void TurnOff()
    {
        gameObject.SetActive(true);
    }
}
