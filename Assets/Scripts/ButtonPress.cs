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
    public AudioClip gameMusic;
    public AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        parentAnimator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown() 
    {
        animator.Play("PressedDown", -1, 0f);
        parentAnimator.SetBool("Start", true);
        audioManager.ChangeBackgroundMusic(gameMusic);
        game.SetActive(true);
        spawner.SetActive(true);
    }
}
