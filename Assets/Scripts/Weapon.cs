using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    float overheatTime;
    bool overheated;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = gameObject.GetComponent(typeof(Player)) as Player;
        overheated = false;
        slider.value = 0;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && spawner.activeInHierarchy && player.alive)
        {
            Shoot();
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void FixedUpdate()
    {
        if (player.animatingWarp)
            return;
        
        if (overheated){
            if (Time.time - overheatTime > 3)
            {
                overheated = false;
                slider.value = 0;
            }
        }
        else if (slider.value > 0)
        {
            if (slider.value >= 1)
            {
                overheated = true;
                overheatTime = Time.time;
            }
            else if (slider.value - Time.deltaTime * 0.05f < 0)
                slider.value = 0;
            else
                slider.value -= Time.deltaTime * 0.15f;
        }
    }

    void Shoot()
    {
        //shooting logic
        if (overheated && !player.coffeeBuff)
            return;
        
        if (player.coffeeBuff) {
            Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y + 0.4f, firePoint.position.z), firePoint.rotation);
            Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y + 0f, firePoint.position.z), firePoint.rotation);
            Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y - 0.4f, firePoint.position.z), firePoint.rotation);
        }
        else {
            Instantiate(bulletPrefab, new Vector3((float)(firePoint.position.x + 0.4), firePoint.position.y, firePoint.position.z), firePoint.rotation);
            slider.value += Time.deltaTime * 15;
        }
        audioManager.playFX(bulletMusic, 0.02f);
    }
}
