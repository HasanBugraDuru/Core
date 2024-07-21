using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensor : MonoBehaviour,ILightAble
{
    public GameObject[] gameObjects;
    public float _lightTimer;
    void Start()
    {
        _lightTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _lightTimer -= Time.deltaTime;
        if (_lightTimer <= 0)
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.GetComponent<IActivatable>().TurnOff();
            }
        }
    }
    public void GetLight()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.GetComponent<IActivatable>().TurnOn();
            _lightTimer = 0.2f;
        }
    }
}
