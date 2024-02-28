using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class EventBus
{
    public static EventBus Instance
    {
        get
        {
            if (theInstance == null)
                theInstance = new EventBus();
            return theInstance;
        }
    }
    static EventBus theInstance;
    // anyone can register an "interest" in the damage event
    public event Action<Damage> onDamage;
    // when damage is dealt, call this method
    // everyone that is interested is notified
    public void Damage(Damage data)
    {
        onDamage?.Invoke(data);
    }
}