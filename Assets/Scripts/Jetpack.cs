using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    void FixedUpdate()
    {
        animator.SetFloat("Height", transform.position.y);
        if (player.animatingWarp)
            rb.velocity = new Vector2(0,0);
        if (player.alive && spawner.activeInHierarchy && !player.animatingWarp)
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
