using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_weatherMan : MonoBehaviour
{
    public GameObject cloud_prefab;
    public GameObject splash_prefab;
    private GameObject cloud_inst;
    int starting_clouds;
    int total_clouds;
    GameObject[] current_clouds;
    int starting_chop;
    int current_chop;
    private GameObject wave_inst;
    Vector3 rand_sea_pos;

    // Start is called before the first frame update
    void Start()
    {
        starting_clouds = Random.Range(2, 8);
        total_clouds = starting_clouds + 1;
        starting_chop = Random.Range(2, 5);

        for (int i = 0; i < starting_clouds; i++)
        {
            Vector3 rand_pos = new Vector3(Random.Range(-7f, 8f), Random.Range(3f, 4f), 0f);
            cloud_inst = Instantiate(cloud_prefab, rand_pos, Quaternion.identity);
            cloud_inst.transform.parent = transform;
        }

        for (int i = 0; i < starting_chop; i++)
        {
            SpawnRandWave();
        }
    }

    // Update is called once per frame
    void Update()
    {
        current_clouds = GameObject.FindGameObjectsWithTag("cloud");
        if (current_clouds.Length < total_clouds)
        {
            Vector3 rand_pos = new Vector3(-9f, Random.Range(3f, 5f), 0f);
            cloud_inst = Instantiate(cloud_prefab, rand_pos, Quaternion.identity);
            cloud_inst.transform.parent = transform;
        }

        if (current_chop < starting_chop)
        {
            StartCoroutine(waveTimer());
        }


    }

    IEnumerator waveTimer()
    {
        current_chop++;

        yield return new WaitForSeconds(Random.Range(0.1f, 0.9f));

        SpawnRandWave();

        current_chop--;
    }

    void SpawnRandWave()
    {
        int wave_range = Random.Range(1, 4);
        switch (wave_range)
        {
            case 4:
                rand_sea_pos = new Vector3(Random.Range(-7f, 7f), Random.Range(1.2f, 1.3f), 0f);
                break;
            case 3:
                rand_sea_pos = new Vector3(Random.Range(5.5f, 7f), Random.Range(1f, -5f), 0f);
                break;
            case 2:
                rand_sea_pos = new Vector3(Random.Range(-7f, -4.5f), Random.Range(1f, -5f), 0f);
                break;
            case 1:
                rand_sea_pos = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, -4.5f), 0f);
                break;
            default:
                rand_sea_pos = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, -4.5f), 0f);
                break;
        }

        wave_inst = Instantiate(splash_prefab, rand_sea_pos, Quaternion.identity);
        wave_inst.transform.parent = transform;
        wave_inst.GetComponent<scr_waterfx>().RandomAnim();
    }
}
