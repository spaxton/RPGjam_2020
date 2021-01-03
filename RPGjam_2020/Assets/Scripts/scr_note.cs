using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_note : MonoBehaviour
{
    public scr_player player_script;

    // Start is called before the first frame update
    void OnEnable()
    {
        player_script.StartReading();
    }

    public void KillNote()
    {
        player_script.StopReading();
        gameObject.SetActive(false);
    }
}
