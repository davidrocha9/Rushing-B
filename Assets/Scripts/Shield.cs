using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
  public static Shield instance;
  Player player;
  Rigidbody2D rb;
  Animator animator;

  // Start is called before the first frame update
  void Start()
  {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = gameObject.GetComponent(typeof(Player)) as Player;
  }

  // Update is called once per frame
  void Update()
  {
        if (!player.shield)
        {
            
        }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    
  }
}
