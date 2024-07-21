using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musix : MonoBehaviour
{
    [SerializeField] Datas datas;

    AudioSource music;
    private void Awake()
    {
        music = GetComponent<AudioSource>();

        if(!datas.MusicOn) music.Pause();
    }
}
