using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float setStartingHealth;
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float minHP;
    private float healthPoint;
    private void Start()
    {
        if (setStartingHealth == 0)
        {
            healthPoint = Random.Range(minHP, maxHP);
        }
        else
        {
            healthPoint = setStartingHealth;
        }
    }
    public void ResieveHit(float iDamage)
    {
        healthPoint -= iDamage;
        Debug.Log(gameObject.name + " took " + iDamage + " amount of damage and now has " + healthPoint + " amount of health");
        if (healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
    public float GetHealth()
    { 
        return healthPoint;
    }
}
