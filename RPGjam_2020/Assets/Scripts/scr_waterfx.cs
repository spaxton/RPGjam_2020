using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_waterfx : MonoBehaviour
{
    Animator animator;
    public string[] triggers;
    string trigger;

    public void RandomAnim()
    {
        animator = GetComponent<Animator>();
        trigger = triggers[Random.Range(0, triggers.Length)];
        animator.SetTrigger(trigger);
    }

    public void SpecAnim(string trigger)
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger(trigger);
    }

    public void KillMe()
    {
        Destroy(gameObject);
    }
}
