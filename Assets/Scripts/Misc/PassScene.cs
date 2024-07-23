using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassScene : MonoBehaviour
{
   [SerializeField]  Datas datas;
   [SerializeField] int Value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            datas.Level = Value;
            WriteAndControl();
        }
    }
    private void WriteAndControl()
    {
        if (datas.Level == 2) SceneManager.LoadScene("PostApocalyptic");
        if (datas.Level == 3) SceneManager.LoadScene("Rescue");
        if (datas.Level == 4) SceneManager.LoadScene("funeral");
        if (datas.Level == 5) SceneManager.LoadScene("Arcade");
        if (datas.Level == 6) SceneManager.LoadScene("Chase1");
        if (datas.Level == 7) SceneManager.LoadScene("Chase2");
        if (datas.Level == 8) SceneManager.LoadScene("Final");
    }
}
