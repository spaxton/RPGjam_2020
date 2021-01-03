using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_weatherMan : MonoBehaviour
{
    public GameObject cloud_prefab;
    private GameObject cloud_inst;
    int starting_clouds;
    int total_clouds;
    GameObject[] current_clouds;

    // Start is called before the first frame update
    void Start()
    {
        starting_clouds = Random.Range(2, 8);
        total_clouds = starting_clouds + 1;

        for(int i = 0; i < starting_clouds; i++)
        {
            Vector3 rand_pos = new Vector3(Random.Range(-7f, 8f), Random.Range(3f, 4f),0f);
            cloud_inst = Instantiate(cloud_prefab, rand_pos, Quaternion.identity);
            cloud_inst.transform.parent = transform;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        current_clouds = GameObject.FindGameObjectsWithTag("cloud");
        if(current_clouds.Length < total_clouds)
        {
            Vector3 rand_pos = new Vector3(-9f, Random.Range(3f, 5f), 0f);
            cloud_inst = Instantiate(cloud_prefab, rand_pos, Quaternion.identity);
            cloud_inst.transform.parent = transform;
        }
    }
}
