using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] Datas datas;
    [SerializeField] private GameObject Esc;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ShowEsc();
    }
    public void ShowEsc()
    {
        datas.EscOpened = !datas.EscOpened;
        if (datas.EscOpened)
        {
            TogglePause();
            Esc.SetActive(true);
        }
        else
        {
            TogglePause();
            Esc.SetActive(false);
        }
    }
    public void CloseEsc()
    {
        TogglePause();
        datas.EscOpened = false;
        Esc.SetActive(false);
    }
    public void MainMenu()
    {
        datas.EscOpened = false;
        datas.isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    private void TogglePause()
    {
        datas.isPaused = !datas.isPaused;
        if (datas.isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void ResetLevel()
    {
        datas.playerTransform = null;
        datas.isPaused = false;
        datas.EscOpened = false;
        Time.timeScale = 1;
        if (datas.Level == 2) SceneManager.LoadScene("PostApocalyptic");
        if (datas.Level == 3) SceneManager.LoadScene("Rescue");
        if (datas.Level == 4) SceneManager.LoadScene("funeral");
        if (datas.Level == 5) SceneManager.LoadScene("Arcade");
        if (datas.Level == 6) SceneManager.LoadScene("Chase1");
        if (datas.Level == 7) SceneManager.LoadScene("Chase2");
        if (datas.Level == 8) SceneManager.LoadScene("Final");
    }
}
