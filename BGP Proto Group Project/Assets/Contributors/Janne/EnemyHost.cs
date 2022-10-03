using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class EnemyHost : MonoBehaviour
    {
        private GameObject playerGameObject;
        public GameObject enemyPrefab;
        void Start()
        {
            //finds the player and spawns an enemy to hunt it
            playerGameObject = transform.parent.Find("Player").gameObject;
            SpawnEnemy();
        }
        public void SpawnEnemy()
        {
            //spawns an enemy and gives it its target(player transform)
            GameObject instantiatedEnemy = Instantiate(enemyPrefab,new Vector2(10,0),new Quaternion(0,0,0,0));
            instantiatedEnemy.GetComponent<EnemyAI>().targetTransform = playerGameObject.transform;
        }
        //meant for more ellaborate spawning of enemies
        public void SpawnEnemy(Vector2 iSpawnEnemyLocation)
        {
            //spawns an enemy and gives it its target(player transform)
            GameObject instantiatedEnemy = Instantiate(enemyPrefab, iSpawnEnemyLocation, new Quaternion(0, 0, 0, 0));
            instantiatedEnemy.GetComponent<EnemyAI>().targetTransform = playerGameObject.transform;
        }
    }