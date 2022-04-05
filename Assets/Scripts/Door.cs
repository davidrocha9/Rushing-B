using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  private Vector3 _startPosition;
  public float frequency = 10f;
  public float magnitude = 1f;
  public float offset = 0f;
  float speed;
  CameraMovement cameraMovement;

  // Start is called before the first frame update
  void Start()
  {
    _startPosition = transform.position;
    cameraMovement = GameObject.FindGameObjectsWithTag("CameraMovement")[0].GetComponent<CameraMovement>();
    speed = cameraMovement.speed;
  }

  // Update is called once per frame
  void Update()
  {
    speed = cameraMovement.speed;
    if (transform.position.x < -10) 
    {
      Destroy(this.gameObject);
    }
    _startPosition.x = _startPosition.x - Time.deltaTime * 5;
    //transform.position = _startPosition + transform.up * 0;
    transform.Translate(Vector3.left*speed*Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {

  }
}
