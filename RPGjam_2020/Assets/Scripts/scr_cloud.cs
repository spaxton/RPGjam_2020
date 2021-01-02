using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cloud : MonoBehaviour
{
    public Sprite[] cloud_types;
    float speed;

    Vector3 start_pos;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = cloud_types[Random.Range(0, cloud_types.Length)];
        speed = Random.Range(0.0001f, 0.001f);
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed, 0, 0);

        if (transform.position.x > (9f))
        {
            Destroy(gameObject);
        }
    }
}
