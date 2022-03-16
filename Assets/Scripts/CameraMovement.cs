using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public Vector3 startPos;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.alive)
        {
            transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
        else{
            Debug.Log(speed);
            speed = speed - 0.05f;
            if (speed > 0)
                transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
        if (transform.position.x < -53.84579)
        {
            transform.position = startPos;
        }
    }
}