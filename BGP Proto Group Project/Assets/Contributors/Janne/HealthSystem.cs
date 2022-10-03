using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float health;
    private void Start()
    {
        health = Random.Range(10,30);
    }
    public void GetHit(float iDamage)
    {
        health -= iDamage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
