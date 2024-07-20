using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniDatas", menuName = "Mini Datas")]
public class Minigamedatas : ScriptableObject  
{
    public bool EscOpened, isPaused, MusicOn, SoundOn;
    public bool canSpawn;
    public bool DeadMenuOpend;
}
