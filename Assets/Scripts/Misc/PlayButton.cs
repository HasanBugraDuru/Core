
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   [SerializeField] Datas datas;

    public void Play()
    {
            if(datas.Level == 0) SceneManager.LoadScene("Story");
            if(datas.Level == 1) SceneManager.LoadScene("PreApocalyptic");
            if(datas.Level == 2) SceneManager.LoadScene("PostApocalyptic");
            if(datas.Level == 3) SceneManager.LoadScene("Rescue");   
            if(datas.Level == 4) SceneManager.LoadScene("funeral");   
            if(datas.Level == 5) SceneManager.LoadScene("Rescue");   
            if(datas.Level == 6) SceneManager.LoadScene("Puzzel");   
            if(datas.Level == 7) SceneManager.LoadScene("Arcade");   
            if(datas.Level == 8) SceneManager.LoadScene("Chase1");   
            if(datas.Level == 9) SceneManager.LoadScene("Chase2");   
            if(datas.Level == 10) SceneManager.LoadScene("Final");   
    }
}
