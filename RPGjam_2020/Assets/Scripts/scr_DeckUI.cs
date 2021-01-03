using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_DeckUI : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenu;

    public scr_player player;

    public GameObject ContextClue;
    public Text Con_Text;
    public bool ContextUp;

    public GameObject Note;


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

    public void spawnNote()
    {
        Note.SetActive(true);
    }

    public void canfish_trigger()
    {
        StartCoroutine(canfish_timer());
    }

    public IEnumerator canfish_timer()
    {
        yield return new WaitForSeconds(2f);

        if (player.can_fish && ContextUp == false)
        {
            ContextClue.GetComponent<Animator>().SetTrigger("rise");
            ContextClue.GetComponent<Animator>().ResetTrigger("drop");
            ContextUp = true;
        }
        Con_Text.text = "GO FISHING";
    }

    public void canreel_trigger()
    {
        StartCoroutine(canreel_timer());
    }

    public IEnumerator canreel_timer()
    {
        yield return new WaitForSeconds(1f);

        if (player.can_fish && ContextUp == false)
        {
            ContextClue.GetComponent<Animator>().SetTrigger("rise");
            ContextClue.GetComponent<Animator>().ResetTrigger("drop");
            ContextUp = true;
        }
        Con_Text.text = "REEL IN";
    }

    public void canread_trigger()
    {
        StartCoroutine(canread_timer());
    }

    public IEnumerator canread_timer()
    {
        yield return new WaitForSeconds(1f);

        if (player.can_int && ContextUp == false)
        {
            ContextClue.GetComponent<Animator>().SetTrigger("rise");
            ContextClue.GetComponent<Animator>().ResetTrigger("drop");
            ContextUp = true;
        }
        Con_Text.text = "READ NOTE";
    }

    public void drop_context()
    {
        ContextClue.GetComponent<Animator>().SetTrigger("drop");
        ContextClue.GetComponent<Animator>().ResetTrigger("rise");
        ContextUp = false;
    }





}
