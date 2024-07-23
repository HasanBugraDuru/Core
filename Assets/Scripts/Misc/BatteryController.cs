using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryController : MonoBehaviour
{
    [SerializeField] Image Bateryfiller;
    [SerializeField] Datas datas;
    bool batteryon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Battery"))
        {
            batteryon = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Battery"))
        {
            batteryon = false;
        }
    }
}
