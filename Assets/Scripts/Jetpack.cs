using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public int jumpforce;
    Rigidbody2D rb;
    Animator animator;
    Player player;
    public int cnt = 0;

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
        if (player.alive)
        {
            animator.SetFloat("Height", transform.position.y);
            if (Input.GetKey("up"))
            {
                cnt += 1;
                rb.AddForce(Vector2.up*jumpforce);
                animator.SetBool("Falling", false);
            }
            else {
                animator.SetBool("Falling", true);
            }
        }
    }
}
