using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    private Vector3 _startPosition;
    public float frequency = 5f;
    public float magnitude = 5f;
    public float offset = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.x < -10){
            Destroy(this.gameObject);
        }
        _startPosition.x = _startPosition.x - Time.deltaTime*5;
        transform.position = _startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreController.instance.increaseNotebooks();
        }
    }
}
