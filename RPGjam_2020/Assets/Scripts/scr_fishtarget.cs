using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_fishtarget : MonoBehaviour
{
    public Transform player_trans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player_trans.position.x, player_trans.position.y, this.transform.position.z);
    }
}
