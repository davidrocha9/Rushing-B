using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIJetpack : MonoBehaviour
{
    public int jumpforce;
    Rigidbody2D rb;
    Animator animator, statsAnimator;
    private Vector3 _startPosition;
    public float frequency = 5f;
    public float magnitude = 5f;
    public float offset = 0f;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public SpriteRenderer spriteR;
    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _startPosition = transform.position;
        statsAnimator = GameObject.FindGameObjectsWithTag("Stats")[0].GetComponent<Animator>();
        slider = GameObject.FindGameObjectsWithTag("HealthBar")[0].GetComponent<Slider>();
        fill = GameObject.FindGameObjectsWithTag("Fill")[0].GetComponent<Image>();
        slider.value = 100;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        statsAnimator.Play("TeacherStats_FadeIn");
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        if (spriteR.sprite.name == "teacher2_flying_spritesheet_0")
        {
            Debug.Log("goods");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (transform.position.x > 7.5)
            {
                _startPosition.x = _startPosition.x - Time.deltaTime;
            }
            transform.position = _startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
        }
        else
        {
            transform.Translate(Vector3.left*7*Time.deltaTime);
            if(transform.position.x < -11)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Bullet"))
        {
            slider.value -= 10;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            if (slider.value == 0)
            {
                statsAnimator.Play("TeacherStats_FadeOut");
                Debug.Log(spriteR.sprite.name);
                if (spriteR.sprite.name.Contains("teacher1"))
                {
                    animator.Play("Teacher1_Dead");
                }
                else if (spriteR.sprite.name.Contains("teacher2"))
                {
                    animator.Play("Teacher2_Dead");
                }
                else
                {
                    animator.Play("Teacher3_Dead");
                }

                rb.gravityScale = 2;
                alive = false;
            }
        }
    }
}
