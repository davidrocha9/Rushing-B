using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public int health = 3;
    public int rotation = 0;
    private Vector2 screenBounds;
    public GameObject warningPrefab, warningPrefab2;
    GameObject warning;
    GameObject player;
    float spawnTime;
    bool increaseOpacity, secondPhase;
    SoundFXManager audioManager;
    public AudioClip warningMusic, deployMusic;
    Pause pauseMenu;
    CameraMovement cameraMovement;
    float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        player = GameObject.Find("Player");
        warning = Instantiate(warningPrefab) as GameObject;
        warning.transform.position = new Vector2(5, player.transform.position.y);
        warning.GetComponent<SpriteRenderer>().color -= new Color (0, 0, 0, 1);
        increaseOpacity = false;
        secondPhase = false;
        audioManager = GameObject.FindGameObjectsWithTag("SoundFX")[0].GetComponent<SoundFXManager>();
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu")[0].GetComponent<Pause>();
        cameraMovement = GameObject.FindGameObjectsWithTag("CameraMovement")[0].GetComponent<CameraMovement>();
        speed = cameraMovement.speed * 2.43f;
    }

    void animateWarning(GameObject warning)
    {
        if (warning.GetComponent<SpriteRenderer>().color.a <= 0)
        {
            increaseOpacity = true;
        }
        else if (warning.GetComponent<SpriteRenderer>().color.a >= 1)
        {
            increaseOpacity = false;
        }

        if (increaseOpacity)
        {
            warning.GetComponent<SpriteRenderer>().color += new Color (0, 0, 0, 0.025f);
        }
        else
        {
            warning.GetComponent<SpriteRenderer>().color -= new Color (0, 0, 0, 0.025f);
        }
    }

    void Awake(){
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.isPaused())
            return;
        
        if (Time.time - spawnTime < 2.0f)
        {
            if (Time.time - spawnTime > 1.0f && !secondPhase && !warning.GetComponent<SpriteRenderer>().sprite.name.Contains("warning2"))
            {   
                secondPhase = true;
                audioManager.playFX(warningMusic);
                float y = warning.transform.position.y;
                Destroy(warning);
                warning = Instantiate(warningPrefab2) as GameObject;
                warning.transform.position = new Vector2(7.5f, y);
            } 
            
            if (!secondPhase)
            {
                warning.transform.position = new Vector2(7.5f, player.transform.position.y);
            }

            animateWarning(warning);
        }
        else
        {
            if (warning != null)
            {
                audioManager.playFX(deployMusic);
                transform.position = new Vector2(10, warning.transform.position.y);
                Destroy(warning);
            }
            if(transform.position.x < -10){
                Destroy(this.gameObject);
            }
            rotation += 5;
            transform.localRotation = Quaternion.Euler(0, 0, rotation);
            transform.Translate(Vector3.left*speed*Time.deltaTime,Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            if(transform.position.x < 10) {
                if (health > 0) health--;
                else Destroy(this.gameObject);
            }
        }
    }
}
