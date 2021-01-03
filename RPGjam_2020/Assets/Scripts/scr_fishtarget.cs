using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_fishtarget : MonoBehaviour
{
    public Transform player_trans;
    private float hor_mod = 0f;
    private float ver_mod = -2f;
    public GameObject player;

    private Vector3 lastPos;
    private Vector3 player_vel;
    private Vector3 player_dir;
    private bool good_spot = false;
    public bool can_fish = false;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = player_trans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_trans.position == lastPos)
        {
            if(good_spot == true)
            {
                //Debug.Log("can fish");
                can_fish = true;
            } else
            {
                //Debug.Log("can't fish");
                can_fish = false;
            }
            //Debug.Log("stopped");

        } else
        {
            player_vel = (player_trans.position - lastPos);
            player_dir = player_vel.normalized;

            hor_mod = player_dir.x * 1.6f;
            //Debug.Log("player vert mod: " + player_dir.y);
            if (player_dir.y <= 0)
            {
                ver_mod = player_dir.y * 1.6f;
            } else if (player_dir.y > 0)
            {
                ver_mod = player_dir.y * 0.5f;
            }
            

            this.transform.position = new Vector3(player_trans.position.x + hor_mod, player_trans.position.y + ver_mod - 0.6f, this.transform.position.z);
            //Debug.Log("can't fish");
            can_fish = false;
        }

        lastPos = player_trans.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "fishing_spot")
        {
            //Debug.Log("good spot");
            good_spot = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "fishing_spot")
        {
            //Debug.Log("bad spot");
            good_spot = false;
        }
    }


}
