using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    public GameOverScreen GameOverScreen;
    public ScoreController scoreController;
    public Deploy spawner;
    public bool alive = true;
    public bool shield = false;
    public bool coffeeBuff = false;
    public bool invincibility = false;
    public bool activatePower = false;
    public SoundFXManager audioManager;
    public AudioClip coinFX, shockedFX, trashCanFX, doorFX, deadFX, shieldFX, shieldBreakFX, coffeeFX;
    Rigidbody2D rb;
    Animator animator;
    public bool animatingWarp;
    int animatingCnt, animatingFrames;
    CameraMovement cameraMovement;
    float speed;
    public TextMeshProUGUI powerUpAvailable, cost;

    void animateCoins()
    {   
        if (!(GameObject.FindGameObjectsWithTag("Teacher").Length == 0) && coffeeBuff == false)
        {
            if (System.Int32.Parse(scoreController.coins.text) >= (100 + 100 * scoreController.coffeeBoughtCnt))
            {
                activatePower = true;
                powerUpAvailable.color = new Color32(0, 0, 0, 255);
                cost.text = "Cost: " + (100 + 100 * scoreController.coffeeBoughtCnt).ToString();
                powerUpAvailable.text = "Power up available";
            }
            else {
                cost.text = "";
                powerUpAvailable.text = "";
                return;
            }

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
        InvokeRepeating("animateCoins", 0.0f, 0.5f);
        animatingWarp = false;
        animatingCnt = 0;
        cameraMovement = GameObject.FindGameObjectsWithTag("CameraMovement")[0].GetComponent<CameraMovement>();
        speed = cameraMovement.speed;
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
            scoreController.buyCoffee();
            activatePower = false;
        }

        if (animatingWarp)
        {
            if (animatingCnt > 100 && animatingCnt < 200)
            {
                cameraMovement.speed -= (100-scoreController.speed)/100;
            }
            animatingCnt++;

            if (animatingCnt > 200)
            {
                animatingWarp = false;
                animatingCnt = 0;
                rb.gravityScale = 2;
                spawner.gameObject.SetActive(true);
                scoreController.gameObject.SetActive(true);
                scoreController.animateMeters();
                spawner.reactivate();
                rb.gravityScale = 2;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (alive) {
            if (other.gameObject.CompareTag("Coins"))
            {
                audioManager.playFX(coinFX);
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
                audioManager.playFX(shieldFX);
            }
            else if (other.gameObject.CompareTag("TrashCan"))
            {
                if (invincibility) {

                }
                else if (shield && !invincibility) {
                    shield = false;
                    audioManager.playFX(shieldBreakFX);
                }
                else {
                    audioManager.playFX(trashCanFX);
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
                    audioManager.playFX(shieldBreakFX);
                }
                else {
                    audioManager.playFX(shockedFX);
                    alive = false;
                    DeleteAll();
                    GameOverScreen.Setup();
                    animator.SetBool("Shocked", true);
                }
            }
            else if (other.gameObject.CompareTag("Coffee"))
            {
                animator.SetBool("Aura", true);
                audioManager.playFX(coffeeFX);
                Destroy(other.gameObject);
                coffeeBuff = true;
                StartCoroutine(DisableCoffeeBuff());

            }
            else if (other.gameObject.CompareTag("EnemyBullet"))
            {
                if (invincibility) {

                }
                else if (shield && !invincibility) {
                    shield = false;
                    audioManager.playFX(shieldBreakFX);
                }
                else {
                    audioManager.playFX(deadFX);
                    alive = false;
                    DeleteAll();
                    GameOverScreen.Setup();
                    animator.Play("Dead");
                }
            }
            else if (other.gameObject.CompareTag("EnemyBullet"))
            {
                if (invincibility) {

                }
                else if (shield && !invincibility) {
                    shield = false;
                    audioManager.playFX(shieldBreakFX);
                }
                else {
                    audioManager.playFX(deadFX);
                    alive = false;
                    DeleteAll();
                    GameOverScreen.Setup();
                    animator.Play("Dead");
                }
            }
            else if (other.gameObject.CompareTag("Door"))
            {
                Debug.Log("goods");
                audioManager.playFX(doorFX);
                
                ScoreController.instance.doorWarp();
                Destroy(other.gameObject);
                animateDoorWarp();
                cameraMovement.speed = 100;
            }
        }
    }

    public void DeleteAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.CompareTag("TrashCan") || o.CompareTag("Mask") || o.CompareTag("Notebook") || o.CompareTag("Coins") || o.CompareTag("Teacher") || o.CompareTag("Coffee")
            || o.CompareTag("Stats") || o.CompareTag("Warning") || o.CompareTag("LightBulb") || o.CompareTag("LightBulbInverted") || o.CompareTag("Door"))
            {
                Destroy(o);
            }
        }
    }

    public void DoorSkipDelete()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.CompareTag("TrashCan") || o.CompareTag("Mask") || o.CompareTag("Notebook") || o.CompareTag("Coins") || o.CompareTag("Coffee")
            || o.CompareTag("Warning") || o.CompareTag("LightBulb") || o.CompareTag("LightBulbInverted"))
            {
                Destroy(o);
            }
        }
    }

    void animateDoorWarp()
    {
        DoorSkipDelete();
        spawner.deactivate();
        rb.gravityScale = 0;
        scoreController.gameObject.SetActive(false);
        rb.gravityScale = 0;
        animatingWarp = true;
    }
    
    IEnumerator DisableCoffeeBuff()
    {
        yield return new WaitForSeconds(10);
        animator.SetBool("Aura", false);
        coffeeBuff = false;
    }
}