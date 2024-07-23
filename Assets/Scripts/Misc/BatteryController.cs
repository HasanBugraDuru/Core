using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class BatteryController : MonoBehaviour
{
     Tutorial OldMan;

    [SerializeField] CampStory campStory;
    [SerializeField] float Energy;
    [SerializeField] Image batteryfiller;
    [SerializeField] Datas datas;
    [SerializeField] GameObject battery;
    [SerializeField] GameObject Sing;
    [SerializeField] GameObject light1, light2;
    [SerializeField] TextMeshProUGUI Singtext;
    [SerializeField] float MaxEnergy;
    float CurretEnergy;
    bool opened;
    bool batteryon;
 
    private void Update()
    {
        InputPlayer();
        ControlEnergy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            batteryon = true;
            Singtext.text = "X";
            Sing.SetActive(true);
            battery.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            batteryon = false;
            Sing.SetActive(false);
            battery.gameObject.SetActive(false);
        }
    }
    private void ControlEnergy()
    {
        if(CurretEnergy / MaxEnergy >=0.98f)
        {
            light1.SetActive(true);
            light2.SetActive(true);
            if (!opened)
            {
                campStory.StartDialogue();
                opened = true;
            }
        }
    }
    private void FillBattery()
    {
        batteryfiller.fillAmount = CurretEnergy/MaxEnergy;
    }
    private void InputPlayer()
    {
        if (batteryon)
        {
            if (Input.GetKey(KeyCode.X))
            {
                if (datas.BatteryAmount > 0)
                {
                        datas.BatteryAmount -= Energy *Time.deltaTime;
                        CurretEnergy += Energy * Time.deltaTime;
                        FillBattery();
                }
            }
            
        }
    }
}
