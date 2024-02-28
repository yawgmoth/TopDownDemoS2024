using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public Damage(float dmg, DamageType t, GameObject source)
    {
        this.damage = dmg;
        this.type = t;
        this.source = source;
    }
    public enum DamageType { PHYSICAL, FIRE, WATER, EARTH, WIND };
    public float damage;
    public DamageType type;
    public GameObject source;
    public GameObject target;
}
