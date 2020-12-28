using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DeckUI : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenu;

    public scr_player player;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        player.StartReading();
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Resume()
    {
        player.StopReading();
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void EndGame()
    {
        Application.Quit();
    }

    
}
