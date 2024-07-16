using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinnButonn : MonoBehaviour
{
    [SerializeField] private Datas datas;
    [SerializeField] private GameObject pinnPanel;
    [SerializeField] private TextMeshProUGUI pinnText;

    public void ControlPinn()
    {
        if(datas.password == pinnText.text)
        {
            Debug.Log("Correcto");
        }
    }
    public void ClosePinnPanel()
    {
        pinnPanel.SetActive(false);
    } 
}
