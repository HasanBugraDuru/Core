using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAndAudio : MonoBehaviour
{
    [SerializeField] bool ismusic, isaudio;
    [SerializeField] AudioSource music;
    [SerializeField] Datas datas;
    [SerializeField] private Sprite MusicOn, MusicOff, SoundOn, SoundOff;

    private Image image;
    private void Awake()
    {
       image = GetComponent<Image>();
       if(isaudio) ControlSound();
       if(ismusic) ControlMusic();
    }
    public void ControlMusic()
    {
        if (datas.MusicOn)
        {
            image.sprite = MusicOn;
            music.UnPause();
        }
        else
        {
            image.sprite = MusicOff;
            music.Pause();
        }
        
    }
    public void MusicButton()
    {
        datas.MusicOn = !datas.MusicOn;
        ControlMusic();
    }
    public void SoundButton()
    {
        datas.SoundOn = !datas.SoundOn;
        ControlSound();
    }
    public void ControlSound()
    {
        if (datas.SoundOn)
        {
            image.sprite = SoundOn;
        }
        else
        {
            image.sprite = SoundOff;
        }
    }
}
