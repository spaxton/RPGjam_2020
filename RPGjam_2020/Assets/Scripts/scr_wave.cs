using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_wave : MonoBehaviour
{
    public int WaveNum;
    public Animator animator;

    float start_pos;
    bool go_left;


    // Start is called before the first frame update
    void Start()
    {
        NewWave_static();
        start_pos = transform.position.x;
    }

    void FixedUpdate()
    {
        if (go_left)
        {
            transform.position = transform.position + (new Vector3(-0.01f, 0, 0));
        } else
        {
            transform.position = transform.position + (new Vector3(0.01f, 0, 0));
        }

        if (transform.position.x >= start_pos + 1f)
        {
            go_left = true;
        }

        if (transform.position.x <= start_pos - 1f)
        {
            go_left = false;
        }

    }

    public void NewWave_static()
    {
        WaveNum = Random.Range(0, 3);
        animator.SetInteger("wave", WaveNum);
    }
}
