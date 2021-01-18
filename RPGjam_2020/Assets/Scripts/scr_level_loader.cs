using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_level_loader : MonoBehaviour
{
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int level, int trans)
    {
        StartCoroutine(LoadTimer(level, trans));
    }

    IEnumerator LoadTimer(int level, int trans)
    {
        if(trans == 1)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(1f);
        } else
        {
            transition.SetTrigger("Swirl");
            yield return new WaitForSeconds(2f);
        }

        

        SceneManager.LoadScene(level);
    }
}
