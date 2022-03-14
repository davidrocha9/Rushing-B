using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public int value = 1, rotation = 0;
    public float speed = 60.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -10){
            Destroy(this.gameObject);
        }
        rotation += 1;
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreController.instance.ChangeScore(value);
        }
    }
}
