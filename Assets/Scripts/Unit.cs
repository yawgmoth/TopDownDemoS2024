using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float hp;
    public float max_hp;
    public bool isPlayer;
    public float physicalArmor;
    public float elementalArmor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(Damage damage)
    {
        float effective_damage;
        if (damage.type == global::Damage.DamageType.PHYSICAL)
        {
            effective_damage = damage.damage - physicalArmor;
        }
        else
        {
            effective_damage = damage.damage - elementalArmor;
        }
        hp -= effective_damage;

        EventBus.Instance.Damage(new global::Damage(effective_damage, damage.type, damage.source));
        if (hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
