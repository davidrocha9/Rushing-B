using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.FindGameObjectsWithTag("HealthBar")[0].GetComponent<Slider>();
        InvokeRepeating("Shoot", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0)
        {
            CancelInvoke("Shoot");
        }
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, new Vector3(transform.position.x - 0.925f, transform.position.y + 0.4f, transform.position.z), transform.rotation);
    }
}