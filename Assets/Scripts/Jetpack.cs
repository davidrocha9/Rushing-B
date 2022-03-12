using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public int speed, jumpforce;
    Rigidbody2D rb;
    public Sprite flying, running;
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
            //transform.position = new Vector2(0, Mathf.Clamp(transform.position.x, -2f, 2f));
        }
        if (transform.position.y == -5.512523)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = running;
        }
        else {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = flying;
        }
    }
}
