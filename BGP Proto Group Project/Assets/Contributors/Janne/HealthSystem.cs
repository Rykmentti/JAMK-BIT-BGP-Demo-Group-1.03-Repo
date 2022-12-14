using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float startingHealth;
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float minHP;
    private float healthPoint;
    [SerializeField]
    float colourFloat = 0.80f;

    ColourChanse bodyColor;
    private void Start()
    {
        bodyColor = gameObject.GetComponent<ColourChanse>();
        if (startingHealth == 0)
        {
            healthPoint = Random.Range(minHP, maxHP);
            startingHealth = healthPoint;
        }
        else
        {
            healthPoint = startingHealth;
        }
    }
    private void Update()
    {
        if(healthPoint < (startingHealth * colourFloat))
        {
            bodyColor.ColourHalfHealth();
            colourFloat -= 0.20f;
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
        if (gameObject.name == "Player")
        {
            //add ui interface here.
        }
    }
    public float GetHealth()
    { 
        return healthPoint;
    }
    public float GetHealthMax()
    {
        return maxHP;
    }
}
