using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToActivate : MonoBehaviour,Iinteractable
{
    public GameObject[] gameObjects;
    public bool isOn;

    void Start()
    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Interact()
    {
        if (isOn == true)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.GetComponent<IActivatable>().TurnOff();
                
            }
            isOn = false;
        }
        else
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.GetComponent<IActivatable>().TurnOn();

            }
            isOn = true;
        }

    }
}
