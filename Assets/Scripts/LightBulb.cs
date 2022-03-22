using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    public BoxCollider2D bc;
    private Vector2 screenBounds;
    public int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*7*Time.deltaTime);

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
