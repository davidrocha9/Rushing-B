using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public int jumpforce;
    public GameObject spawner;
    Rigidbody2D rb;
    Animator animator;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = gameObject.GetComponent(typeof(Player)) as Player;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Height", transform.position.y);
        if (player.alive && spawner.activeInHierarchy)
        {
            if (Input.GetKey("up"))
            {
                rb.AddForce(Vector2.up*jumpforce);
                animator.SetBool("Falling", false);
            }
            else {
                animator.SetBool("Falling", true);
            }
        }
    }
}
