using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject spawner;
    public SoundFXManager audioManager;
    public AudioClip bulletMusic;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = gameObject.GetComponent(typeof(Player)) as Player;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && spawner.activeInHierarchy)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //shooting logic
        if (player.coffeeBuff) {
            Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y + 0.4f, firePoint.position.z), firePoint.rotation);
            Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y + 0f, firePoint.position.z), firePoint.rotation);
            Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y - 0.4f, firePoint.position.z), firePoint.rotation);
        }
        else {
            Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y, firePoint.position.z), firePoint.rotation);
        }
        audioManager.playFX(bulletMusic, 0.02f);
    }
}
