using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Tower : MonoBehaviour
{
    [SerializeField] Light2D Light2D1;
    [SerializeField] Light2D Light2D2;
    [SerializeField] Light2D Light2D3;
    [SerializeField] Light2D Light2D4;
    [SerializeField] Light2D Light2D5;

    bool light;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Light2D1.intensity += 1f * Time.deltaTime;
            }
        }
    }
}
