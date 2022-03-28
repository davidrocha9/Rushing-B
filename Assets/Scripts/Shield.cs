using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    Animator animator;
    public GameObject shieldPrefab;
    public bool active = false;

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
        if(player.shield && !active) {
            active = true;
            // TODO: activate shield sprite
            // GameObject shield = Instantiate(shieldPrefab) as GameObject;
        }
        else if(!player.shield && active) {
            active = false;
            // TODO: deactivate shield sprite
        }
    }
}
