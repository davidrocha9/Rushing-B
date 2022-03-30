using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    Animator animator;
    private Vector3 _startPosition;
    public float frequency = 10f;
    public float magnitude = 1f;
    public float offset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = gameObject.GetComponent(typeof(Player)) as Player;
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() 
    {
        if (transform.position.x < -10) {
            Destroy(this.gameObject);
        }
        _startPosition.x = _startPosition.x - Time.deltaTime * 5;
        transform.position = _startPosition + transform.up * Mathf.Cos(Time.time * frequency + offset) * magnitude;
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
