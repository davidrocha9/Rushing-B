using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 10, initSpeed;
    private Vector2 screenBounds;
    Player player;
    CameraMovement cameraMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        initSpeed = speed;
        player = (Player) Resources.FindObjectsOfTypeAll(typeof(Player))[0];
        cameraMovement = GameObject.FindGameObjectsWithTag("CameraMovement")[0].GetComponent<CameraMovement>();
        speed = cameraMovement.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.alive)
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
        
        if(transform.position.x < -9.039994){
            Destroy(this.gameObject);
        }
    }
}
