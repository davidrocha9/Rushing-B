using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraMovement : MonoBehaviour
{
    public float speed, initSpeed;
    public Vector3 startPos;
    public Player player;
    public GameObject gameStarted;
    public TextMeshProUGUI meters;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
        startPos = transform.position;
        initSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {    
        if (gameStarted.activeInHierarchy && speed < 15 && GameObject.FindGameObjectsWithTag("Teacher").Length == 0)
            speed += Time.deltaTime * 0.05f;

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
        if (transform.position.x < -53.84579)
        {
            transform.position = startPos;

        }
    }
}