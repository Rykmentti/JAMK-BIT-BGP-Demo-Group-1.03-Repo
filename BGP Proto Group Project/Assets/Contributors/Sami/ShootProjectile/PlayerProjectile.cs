using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
    //This script will give speed to the arrow and decide how much damage it does.
    //Should be attached to the projectile. It should be already attached.
{
    public float damage;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        damage = 0; //Insert amount of damage here. If you want to test stuff, leave damage at zero.
        speed = 10; //How fast the arrow travels.
    }

    // Update is called once per frame
    void Update()
    {
        //This moves the projectile forwards.
        transform.Translate(new Vector2(0f, 1f) * speed * Time.deltaTime);
    }
    //Collision Detector
    void OnTriggerEnter2D(Collider2D collision) //Change identifier to whatever you want. We want to hit the collider, that is around the sprite/object to simulate a "hit".
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //collision.gameObject.GetComponent</*Name of the script, that is attached to player*/>()./*variable that represents healthPoint*/ -= damage; //Insert needed identifiers within */ and /* after wards remove wrappers.
            //Destroy(gameObject); //Or just destroy the object outright.
        }
    }
}
