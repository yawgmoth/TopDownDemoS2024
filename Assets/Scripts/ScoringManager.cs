using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringManager : MonoBehaviour
{
    public float points;
    public TextMeshProUGUI text;

    public void DamageIsDealt(Damage damage)
    {
        if (damage.source.CompareTag("Player"))
        {
            points += damage.damage;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        EventBus.Instance.onDamage += DamageIsDealt;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + points.ToString();
    }
}
