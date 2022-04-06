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
    AISoundManager audioManager;
    Deploy spawner;
    public AudioClip jetpackFX, hitFX, deadFX;
    CameraMovement cameraMovement;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _startPosition = transform.position;
        statsAnimator = GameObject.FindGameObjectsWithTag("Stats")[0].GetComponent<Animator>();
        spawner = GameObject.FindGameObjectsWithTag("Spawner")[0].GetComponent<Deploy>();
        slider = GameObject.FindGameObjectsWithTag("HealthBar")[0].GetComponent<Slider>();
        fill = GameObject.FindGameObjectsWithTag("Fill")[0].GetComponent<Image>();
        audioManager = GameObject.FindGameObjectsWithTag("AISoundManager")[0].GetComponent<AISoundManager>();
        slider.value = 100;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        statsAnimator.Play("TeacherStats_FadeIn");
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        cameraMovement = GameObject.FindGameObjectsWithTag("CameraMovement")[0].GetComponent<CameraMovement>();
        speed = cameraMovement.speed;
    }


    // Update is called once per frame
    void Update()
    {
        speed = cameraMovement.speed;
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
            transform.Translate(Vector3.left*speed*Time.deltaTime);
            if(transform.position.x < -11)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (slider.value == 0)
            return;
        
        if (other.gameObject.CompareTag("Bullet"))
        {
            slider.value -= 10;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            if (slider.value == 0)
            {
                spawner.teacherFight = false;
                gameObject.layer = 9;
                audioManager.playFX(deadFX);
                statsAnimator.Play("TeacherStats_FadeOut");
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
            else
            {
                audioManager.playFX(hitFX);
            }
        }
    }
}
