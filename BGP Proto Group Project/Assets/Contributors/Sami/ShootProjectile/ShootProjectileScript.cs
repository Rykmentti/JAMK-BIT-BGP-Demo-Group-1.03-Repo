using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileScript : MonoBehaviour
    //Shoot Projectile Script, attach this script to player.
    //Very simple script, clicking left mouse button will instantiate and turn the gameObject towards where your mouse pointer is. 
{
    // Put these values in Unity Editor. playerCamera is the player Camera object and playerArrow is the player arrow prefab, which is in my own folder.
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject playerArrow;

    [SerializeField] float firerate;
    int maxClipSize;
    int currentClipSize;

    bool shootCooldown;
    bool isReloading;
    // Start is called before the first frame update
    void OnGUI()
    {
        //Comment these out if you don't want to see text on scene.
        GUI.Label(new Rect(10, 10, 1000, 30), "Press Left Click to Shoot!"); 
        GUI.Label(new Rect(10, 30, 1000, 30), "Press R to reload, when out of ammo");
        GUI.Label(new Rect(500, 10, 200, 30), "Ammunition left : " + currentClipSize);
        if (currentClipSize == 0)
        {
            GUI.Label(new Rect(500, 30, 200, 30), "Out of Ammo!");
        }
    }
    void Start()
    {
        firerate = 0.15f; // firerate per second.
        currentClipSize = 30;
        maxClipSize = 30;
    }

    // Update is called once per frame
    void FixedUpdate() //Fixed update for hold buttons, so everything stays consistent. Fixed update, runs 50 times per second by default.
    {
        if (Input.GetKey(KeyCode.Mouse0) && shootCooldown == false && isReloading == false && currentClipSize != 0 )
        {
            ShootProjectile();
            currentClipSize -= 1;
            StartCoroutine(ShootCooldown());
        }
    }
    void Update() // Single activations are better on regular updates, because we want detection be as quick and as accurate as possible.
    {
        if (Input.GetKeyDown(KeyCode.R) && isReloading == false)
        {
            StartCoroutine(IsReloading());
        }
    }
    void ShootProjectile()
    {
        //Okay this is a bit more complicated. This calculates position between your mouse in the unity world space and player position, calculates
        //angle between them and then turns it into quaternion, so we can spawn Game Object in correct angle, so it points towards the mouse pointer.
        Vector3 mousePos = Input.mousePosition;
        Vector2 mouseScreenPosition = playerCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, playerCamera.nearClipPlane));

        float mousePosX = mouseScreenPosition.x;
        float mousePosY = mouseScreenPosition.y;
        float playerPosX = GetComponentInParent<Transform>().position.x;
        float playerPosY = GetComponentInParent<Transform>().position.y;

        Vector2 Point_1 = new Vector2(mousePosX, mousePosY);
        Vector2 Point_2 = new Vector2(playerPosX, playerPosY);
        float rotation = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x) * Mathf.Rad2Deg;
        Vector3 projectileStartRotation = new Vector3(0f, 0f, rotation + 90);
        Quaternion quaternion = Quaternion.Euler(projectileStartRotation);

        Instantiate(playerArrow, transform.position, quaternion);
    }
    IEnumerator IsReloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(2f);
        currentClipSize = maxClipSize;
        isReloading = false;
    }
    IEnumerator ShootCooldown()
    {
        shootCooldown = true;
        yield return new WaitForSeconds(firerate);
        shootCooldown = false;
    }
}
