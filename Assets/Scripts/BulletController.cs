using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float damage;
    public float lifetime;
    public bool isPlayer;
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit u = other.gameObject.GetComponent<Unit>();
        if (u != null)
        {
            if (u.isPlayer != isPlayer)
            {
                u.Damage(new Damage(damage, Damage.DamageType.PHYSICAL, owner));
            }
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
