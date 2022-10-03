using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float minHP;
    private float healthPoint;
    private void Start()
    {
            healthPoint = Random.Range(minHP, maxHP);
    }
    public void ResieveHit(float iDamage)
    {
        healthPoint -= iDamage;
        if (healthPoint < 0)
        {
            Destroy(gameObject);
        }
    }
}
