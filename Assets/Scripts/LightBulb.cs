using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    public BoxCollider2D bc;
    public float speed, initSpeed;
    private Vector2 screenBounds;
    GameObject gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        initSpeed = speed;
        gameOver = GameObject.FindGameObjectsWithTag("GameOver")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
        else{
            speed = speed - 0.05f;
            if (speed > 0)
                transform.Translate(Vector3.left*speed*Time.deltaTime);
            else
                speed = initSpeed + 0.01f;
                initSpeed = speed;
        }
        
        if(transform.position.x < -10){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bc.enabled = false;
        }
    }
}
