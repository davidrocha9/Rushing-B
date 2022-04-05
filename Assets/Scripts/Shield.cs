using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Player player;
    Rigidbody2D rb;
    Animator animator;
    GameObject shield;
    public GameObject shieldPrefab;
    public static bool active = false;
    bool destroyed = false;

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
        if(shield != null) shield.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.2f);

        if (destroyed && shield != null)
        {
            if (shield.GetComponent<SpriteRenderer>().color.a > 0)
            {
                shield.transform.localScale += new Vector3(0.1f, 0.1f, 0);
                shield.GetComponent<SpriteRenderer>().color -= new Color(0f,0f,0f,0.05f);
            }
            else
            {
                Destroy(shield);
            }
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(player.shield && !active) {
            active = true;
            destroyed = false;
            shield = Instantiate(shieldPrefab) as GameObject;
            shield.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.2f);
        }
        else if(!player.shield && active) {
            active = false;
            destroyed = true;
        }
    }
}
