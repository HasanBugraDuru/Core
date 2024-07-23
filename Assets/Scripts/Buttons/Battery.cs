using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    Image battery;

    [SerializeField] Datas datas;

    [SerializeField] float MaxBattery;
    float FillAmount;

    private void Awake()
    {
        battery = GetComponent<Image>();
    }
    private void Update()
    {
        FillAmount = datas.BatteryAmount /MaxBattery;
        battery.fillAmount = FillAmount;
    }
}
