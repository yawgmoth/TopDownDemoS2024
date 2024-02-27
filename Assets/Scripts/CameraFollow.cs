using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float maxdist;
    public float mindist;
    bool moving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;
        if (direction.magnitude > maxdist)
        {
            moving = true;
        }

        if (direction.magnitude < mindist)
        {
            moving = false;
        }

        if (moving)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime,
                                Space.World);
        }
    }
}
