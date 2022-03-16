using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public int rotation = 0;
    private Vector2 screenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -10){
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.left*7*Time.deltaTime);
        rotation += 1;
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Player.instance.(value);
        }
    }
}
