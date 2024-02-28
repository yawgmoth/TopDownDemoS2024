using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Behavior());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotateSlowly(float angle, float time)
    {
        float a = 0;
        while (a < angle)
        {
            float da = Time.deltaTime * (angle / time);
            transform.Rotate(0, da, 0);
            a += da;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Behavior()
    {
        while (true)
        {
            yield return RotateSlowly(45, 2);
            yield return new WaitForSeconds(1);
            Shoot();
            yield return new WaitForSeconds(1);
        }
    }

    void Shoot()
    {
        Quaternion direction = transform.rotation;
        for (int i = 0; i < 4; ++i)
        {
            GameObject b = Instantiate(bullet,
                 transform.position + direction * new Vector3(4.5f, 0, 0),
                 direction);
            BulletController bc = b.GetComponent<BulletController>();
            bc.damage = damage;
            bc.isPlayer = false;
            bc.lifetime = 5;
            bc.speed = 40;
            bc.owner = gameObject;
            direction *= Quaternion.Euler(0, 90, 0);
        }
    }
}
