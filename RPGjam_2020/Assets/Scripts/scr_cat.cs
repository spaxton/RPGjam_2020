using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cat : MonoBehaviour
{
    Animator animator;
    float idleSeconds;
    public string[] triggers;
    string trigger;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        idleTime();
    }

    public void idleTime()
    {
        //Debug.Log("timer has started");

        idleSeconds = Random.Range(0.5f, 3f);
        trigger = triggers[Random.Range(0, triggers.Length)];

        StartCoroutine(playAnim(idleSeconds, trigger));
    }

    public void lookingLeft()
    {
        idleSeconds = Random.Range(1f, 4f);
        StartCoroutine(playAnim(idleSeconds, "right"));
    }

    IEnumerator playAnim(float secs, string trigger)
    {
        yield return new WaitForSeconds(secs);

        animator.SetTrigger(trigger);
    }
}
