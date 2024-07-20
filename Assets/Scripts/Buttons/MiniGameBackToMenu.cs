using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameBackToMenu : MonoBehaviour
{
    [SerializeField] Minigamedatas datas;
    [SerializeField] private GameObject Esc;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ShowEsc();
    }
    public void ShowEsc()
    {
        if (!datas.DeadMenuOpend) 
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
        datas.isPaused = false;
        datas.EscOpened = false;
        Time.timeScale = 1;
        datas.DeadMenuOpend = false;
        SceneManager.LoadScene("MiniGame");
    }
    public void LeaveAcrade() 
    {
        Time.timeScale = 1;
        datas.DeadMenuOpend = false;
        SceneManager.LoadScene("Game");
    }
}
