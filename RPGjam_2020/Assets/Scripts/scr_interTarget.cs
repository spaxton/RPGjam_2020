using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_interTarget : MonoBehaviour
{
    public Transform player_trans;
    public scr_player player;

    private float hor_mod = 0f;
    private float ver_mod = -2f;
    private Vector3 player_vel;
    private Vector3 player_dir;
    private Vector3 lastPos;

    public bool can_int;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = player_trans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_trans.position != lastPos)
        {
            player_vel = (player_trans.position - lastPos);
            player_dir = player_vel.normalized;

            hor_mod = player_dir.x * 0.4f;
            ver_mod = player_dir.y * 0.4f;

            this.transform.position = new Vector3(player_trans.position.x + hor_mod, player_trans.position.y + ver_mod - 0.6f, this.transform.position.z);
            
        }

        lastPos = player_trans.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "interact")
        {
            //Debug.Log("good spot");
            can_int = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "interact")
        {
            //Debug.Log("bad spot");
            can_int = false;
        }
    }
}
