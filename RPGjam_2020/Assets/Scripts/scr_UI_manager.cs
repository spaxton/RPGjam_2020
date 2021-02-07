using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI_manager : MonoBehaviour
{
    public Text Distance;
    public Slider Tension;

    public Text FishName;
    public Text FishRarity;

    bool Paused = false;
    public GameObject PauseMenu;

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
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void updateUI(scr_fish fish)
    {
        Distance.text = fish.dist.ToString() + "m";
        Tension.value = fish.tens;
    }

    public void revealFish(scr_fish fish)
    {
        FishName.text = fish.fishName;
        FishRarity.text = fish.fishRarity;
    }

}
