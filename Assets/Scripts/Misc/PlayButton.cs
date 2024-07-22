using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   [SerializeField] Datas datas;

    public void Play()
    {
        if (datas.Storypassed)
        {
            SceneManager.LoadScene("PreApocalyptic");
        }
        else
        {
            SceneManager.LoadScene("Story");
        }
    }
}
