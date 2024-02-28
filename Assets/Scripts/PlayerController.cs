using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float speed;
    public float fire_rate;
    public float last_shot;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        last_shot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(
            new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 
                        0, 
                        Input.GetAxis("Vertical") * speed * Time.deltaTime));
        Vector3 direction = Camera.main.ScreenToWorldPoint(
                             Input.mousePosition + 
                             new Vector3(0, 0, Camera.main.transform.position.y)) -
                             transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);

        if (Input.GetButton("Fire1") && last_shot + fire_rate < Time.time)
        {
            GameObject b = Instantiate(bullet,
                    transform.position + Quaternion.Euler(0,-90,0)*transform.rotation* new Vector3(2.5f, 0, 0),
                    Quaternion.Euler(0, -90, 0) * transform.rotation);
            BulletController bc = b.GetComponent<BulletController>();
            bc.damage = 30;
            bc.isPlayer = true;
            bc.lifetime = 5;
            bc.speed = 40;
            bc.owner = gameObject;

            last_shot = Time.time;
        }
    }
}
