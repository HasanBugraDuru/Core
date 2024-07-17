using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Datas datas;
    [SerializeField] private Sprite MusicOn, MusicOff,SoundOn,SoundOff;
    [SerializeField] private AudioSource music;
    private Image image;
   public void SoundButton() 
   {
        ControlSound(); 
   }
   public void MusicButton() 
   {
       ControlMusic();
   }
   public void PlayButton() 
   {
        SceneManager.LoadScene("Game");
   }
   public void CreditsButton()
   {
        SceneManager.LoadScene("Credits");
   }
  
    private void Start()
    {
        image = GetComponent<Image>();
        datas.MusicOn = true;
        datas.SoundOn = true;  
    }

    public void ControlMusic()
    {
        if (datas.MusicOn)
        {
            image.sprite = MusicOff;
            datas.MusicOn = false;
            music.Pause();  
        }
        else
        {
            image.sprite = MusicOn;
            datas.MusicOn=true;
            music.UnPause();
        }

    }
    public void ControlSound()
    {
        if (datas.SoundOn)
        {
            image.sprite=SoundOff;
            datas.SoundOn = false;
        }
        else
        {
            image.sprite = SoundOn;
            datas.SoundOn = true;
        }
    }
}
