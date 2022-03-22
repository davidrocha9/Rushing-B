using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 10;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*7*Time.deltaTime);
        if(transform.position.x < -9.039994){
            Destroy(this.gameObject);
        }
    }
}
