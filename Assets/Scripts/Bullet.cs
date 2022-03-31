using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("TrashCan")) {
            Destroy(gameObject);
        }
        // else if (other.gameObject.CompareTag("NPC")) {
        //     Destroy(gameObject);
        // }
    }
}
