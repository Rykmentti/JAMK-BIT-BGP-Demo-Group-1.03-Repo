using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AD1762
{
    public class EnemyAI : MonoBehaviour
    {
        public GameObject targetGameObject;
        public Transform targetTransform;
        public CircleCollider2D attackCircle;
        public float attackSpeed = 1;
        public float timeSinceLastAttack = 0;
        public float speed = 1;
        public bool turnsRight = true;
        private void Start()
        {
            //targetLocation = transform.parent.parent.GetChild();
            targetTransform = targetGameObject.transform;
        }
        private void Update()
        {
            if (targetGameObject != null)
            {
                TurnToTarget();
                MoveForward();
            }
            timeSinceLastAttack += Time.deltaTime;
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.transform.name == "Player")
            {
                if (timeSinceLastAttack > attackSpeed)
                {
                    //Insert attack method call here
                    Debug.Log("hit");
                    timeSinceLastAttack = 0;
                }
            }
            else if(collision.transform.name == "Projectile")
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            
        }
        private void TurnToTarget()
        {
            transform.right = targetTransform.position - transform.position;
        }
        private void MoveForward()
        {
            transform.position = Vector2.MoveTowards(transform.position,targetTransform.position,speed * Time.deltaTime);
        }
    }
}