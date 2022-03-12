using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    public int speed, jumpforce;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            rb.AddForce(Vector2.up*jumpforce);
            //transform.position = new Vector2(0, Mathf.Clamp(transform.position.x, -2f, 2f));
        }
    }
}
