using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIJetpack : MonoBehaviour
{
    public int jumpforce;
    Rigidbody2D rb;
    Animator animator;
    private Vector3 _startPosition;
    public float frequency = 5f;
    public float magnitude = 5f;
    public float offset = 0f;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _startPosition = transform.position;
        slider.value = 100;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector2.up*jumpforce);
        transform.position = _startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Bullet"))
        {
            slider.value -= 10;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
