using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform playerLocation;
    void Update()
    {
        if (playerLocation != null)
        {
            transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y, -10);
        }
    }
}
