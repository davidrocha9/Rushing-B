using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject spawner;

    // Update is called once per frame
    void Update()
    {
        if((Input.GetButtonDown("Fire1") || Input.GetKeyDown("space")) && spawner.activeInHierarchy)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y, firePoint.position.z), firePoint.rotation);
    }
}
