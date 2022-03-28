using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Sprite sprite1, sprite2;
    SpriteRenderer spriteRenderer;
    Animator animator, parentAnimator;
    private Animation anim;
    public GameObject game;
    public GameObject spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        parentAnimator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown() 
    {
        animator.Play("PressedDown", -1, 0f);
        parentAnimator.SetBool("Start", true);
        game.SetActive(true);
        spawner.SetActive(true);
    }
}
