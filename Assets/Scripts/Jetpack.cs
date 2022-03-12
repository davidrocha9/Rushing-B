using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public int speed, jumpforce;
    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Height", transform.position.y);
        if (animator)
        if (Input.GetKey("up"))
        {
            rb.AddForce(Vector2.up*jumpforce);
            animator.SetBool("Falling", false);
            //transform.position = new Vector2(0, Mathf.Clamp(transform.position.x, -2f, 2f));
        }
        else {
            animator.SetBool("Falling", true);
        }
    }
}
