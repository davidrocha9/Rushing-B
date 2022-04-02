using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public GameOverScreen GameOverScreen;
    public bool alive = true;
    public bool shield = false;
    public bool coffeeBuff = false;
    public bool invincibility = false;
    public SoundFXManager audioManager;
    public AudioClip coinFX, shockedFX, trashCanFX, deadFX;
    Rigidbody2D rb;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            audioManager.playFX(coinFX, 0.15f);
            Destroy(other.gameObject);
            ScoreController.instance.increaseCoins();
        }
        else if (other.gameObject.CompareTag("Notebook"))
        {
            Destroy(other.gameObject);
            ScoreController.instance.increaseNotebooks();
        }
        else if (other.gameObject.CompareTag("Mask"))
        {
            Destroy(other.gameObject);
            shield = true;
        }
        else if (other.gameObject.CompareTag("TrashCan"))
        {
            if (invincibility) {

            }
            else if (shield && !invincibility) {
                shield = false;
            }
            else {
                audioManager.playFX(trashCanFX, 0.15f);
                alive = false;
                GameOverScreen.Setup();
                animator.SetBool("Dirty", true);
            }
        }
        else if (other.gameObject.CompareTag("LightBulb") || other.gameObject.CompareTag("LightBulbInverted"))
        {
            if (invincibility) {

            }
            else if (shield && !invincibility) {
                shield = false;
            }
            else {
                audioManager.playFX(shockedFX, 0.15f);
                alive = false;
                GameOverScreen.Setup();
                animator.SetBool("Shocked", true);
            }
        }
        else if (other.gameObject.CompareTag("Coffee"))
        {
            Destroy(other.gameObject);
            coffeeBuff = true;
            StartCoroutine(DisableCoffeeBuff());

        }
        else if (other.gameObject.CompareTag("EnemyBullet"))
        {
            audioManager.playFX(deadFX, 0.15f);
            alive = false;
            GameOverScreen.Setup();
            animator.Play("Dead");
        }
    }

    IEnumerator DisableCoffeeBuff()
    {
        yield return new WaitForSeconds(10);
        coffeeBuff = false;
    }
}