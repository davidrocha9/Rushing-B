using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public int rotation = 0;
    private Vector2 screenBounds;
    public GameObject warningPrefab, warningPrefab2;
    GameObject warning;
    GameObject player;
    float spawnTime;
    bool increaseOpacity, secondPhase;
    
    // Start is called before the first frame update
    void Start()
    {
        float spawnTime = Time.time;
        player = GameObject.Find("Player");
        warning = Instantiate(warningPrefab) as GameObject;
        warning.transform.position = new Vector2(5, player.transform.position.y);
        warning.GetComponent<SpriteRenderer>().color -= new Color (0, 0, 0, 1);
        increaseOpacity = false;
        secondPhase = false;
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

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTime < 5.0f)
        {
            if (Time.time - spawnTime > 4.0f && !secondPhase && !warning.GetComponent<SpriteRenderer>().sprite.name.Contains("warning2"))
            {   
                secondPhase = true;
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
                transform.position = new Vector2(10, warning.transform.position.y);
                Destroy(warning);
            }
            if(transform.position.x < -10){
                Destroy(this.gameObject);
            }
            rotation += 5;
            transform.localRotation = Quaternion.Euler(0, 0, rotation);
            transform.Translate(Vector3.left*14*Time.deltaTime,Space.World);
        }
    }
}
