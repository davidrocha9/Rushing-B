using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    Slider slider;
    Player player;
    SoundFXManager audioManager;
    public AudioClip bulletMusic;

    // Start is called before the first frame update
    void Start()
    {
        player = (Player) Resources.FindObjectsOfTypeAll(typeof(Player))[0];
        slider = GameObject.FindGameObjectsWithTag("HealthBar")[0].GetComponent<Slider>();
        audioManager = GameObject.FindGameObjectsWithTag("SoundFX")[0].GetComponent<SoundFXManager>();
        InvokeRepeating("Shoot", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0 || !player.alive)
        {
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.925f, transform.position.y + 0.4f, transform.position.z), transform.rotation);
        audioManager.playFX(bulletMusic, 0.02f);
    }
}