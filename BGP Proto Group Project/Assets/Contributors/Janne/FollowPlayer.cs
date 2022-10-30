using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerLocation;
    void Start()
    {
        playerLocation = transform.parent.Find("Player").transform;
    }
    void Update()
    {
        if (playerLocation != null)
        {
            transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y, -10);
        }
    }
}
