using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinnNumber : MonoBehaviour
{
    [SerializeField] private int pinnNumber;
    [SerializeField] TextMeshProUGUI pinnText;

    public void AddText()
    {
        if (pinnText.text.Length < 4)
        {
            pinnText.text += pinnNumber;
        }
    }
    public void DellText() 
    { 
        pinnText.text = pinnText.text.Substring(0,pinnText.text.Length-1);
    }
}
