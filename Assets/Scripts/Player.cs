using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public GameOverScreen GameOverScreen;
    public bool alive = true;
    Rigidbody2D rb;
    public BoxCollider2D bc;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            ScoreController.instance.increaseCoins();
        }
        else if (other.gameObject.CompareTag("Notebook"))
        {
            Destroy(other.gameObject);
            ScoreController.instance.increaseNotebooks();
        }
        else if (other.gameObject.CompareTag("TrashCan"))
        {
            alive = false;
            GameOverScreen.Setup();
            animator.SetBool("Dirty", true);
        }
        else if (other.gameObject.CompareTag("LightBulb"))
        {
            alive = false;
            GameOverScreen.Setup();
            animator.SetBool("Shocked", true);
        }
        else if (other.gameObject.CompareTag("EnemyBullet"))
        {
            alive = false;
            GameOverScreen.Setup();
            animator.Play("Dead");
        }
    }
}