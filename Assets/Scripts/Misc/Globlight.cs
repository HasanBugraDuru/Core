using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Globlight : MonoBehaviour
{
    [SerializeField] float value,time;

    Light2D globlight;
    private void Awake()
    {
        globlight = GetComponent<Light2D>();
    }
    private void Update()
    {
        if (globlight.intensity <=time)
        {
            SceneManager.LoadScene("PostApocalyptic");
        }
        globlight.intensity -= value * Time.deltaTime;
    }
}
