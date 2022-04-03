using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    public GameOverScreen GameOverScreen;
    public ScoreController scoreController;
    public bool alive = true;
    public bool shield = false;
    public bool coffeeBuff = false;
    public bool invincibility = false;
    public bool activatePower = false;
    public SoundFXManager audioManager;
    public AudioClip coinFX, shockedFX, trashCanFX, deadFX;
    Rigidbody2D rb;
    Animator animator;


    void animateCoins()
    {
        if (!(GameObject.FindGameObjectsWithTag("Teacher").Length == 0) && coffeeBuff == false)
        {
            activatePower = true;
            if (scoreController.coins.color == new Color32(250, 238, 61, 255))
            {
                scoreController.coins.color = new Color32(255, 0, 0, 255);
            }
            else if (scoreController.coins.color == new Color32(255, 0, 0, 255))
            {
                scoreController.coins.color = new Color32(250, 238, 61, 255);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        InvokeRepeating("animateCoins", 20.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Teacher").Length == 0)
        {
            scoreController.coins.color = new Color32(250, 238, 61, 255);
        }
        if (activatePower == true && Input.GetKeyDown(KeyCode.C) && coffeeBuff == false)
        {
            coffeeBuff = true;
            animator.SetBool("Aura", true);
            StartCoroutine(DisableCoffeeBuff());
            scoreController.buyCoffe();
            activatePower = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (alive) {
            if (other.gameObject.CompareTag("Coins"))
            {
                audioManager.playFX(coinFX, 0.10f);
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
                    DeleteAll();
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
                    DeleteAll();
                    GameOverScreen.Setup();
                    animator.SetBool("Shocked", true);
                }
            }
            else if (other.gameObject.CompareTag("Coffee"))
            {
                animator.SetBool("Aura", true);
                Destroy(other.gameObject);
                coffeeBuff = true;
                StartCoroutine(DisableCoffeeBuff());

            }
            else if (other.gameObject.CompareTag("EnemyBullet") && !shield)
            {
                audioManager.playFX(deadFX, 0.15f);
                alive = false;
                DeleteAll();
                GameOverScreen.Setup();
                animator.Play("Dead");
            }
        }
    }

    public void DeleteAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.CompareTag("TrashCan") || o.CompareTag("Mask") || o.CompareTag("Notebook") ||
            o.CompareTag("Coins") || o.CompareTag("Teacher") || o.CompareTag("Stats") || o.CompareTag("Warning"))
            {
                Destroy(o);
            }
        }
    }

    IEnumerator DisableCoffeeBuff()
    {
        yield return new WaitForSeconds(10);
        animator.SetBool("Aura", false);
        coffeeBuff = false;
    }
}