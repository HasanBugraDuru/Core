using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Datas", menuName = " Datas")]

public class Datas : ScriptableObject
{
    public int Level;
    public float BatteryAmount;
    public float MusicValue;
    public float SoundValue;
    public string password;
    public bool EscOpened,isPaused, MusicOn,SoundOn;

    public Transform playerTransform;
}
