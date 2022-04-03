using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioSource playerFX;
    public GameObject player;
    public AudioClip footsteps, jetpack;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = player.gameObject.GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -3.6)
        {
            if (playerFX.clip != footsteps)
            {
                playerFX.clip = footsteps;
                playerFX.Play();
            }
        }
        else
        {
            if (animator.GetBool("Falling"))
            {
                playerFX.Pause();
            }
            else
            {
                if (playerFX.clip != jetpack)
                {
                    playerFX.clip = jetpack;
                    playerFX.Play();
                }
                else
                {
                    playerFX.UnPause();
                }
            }
        }
    }
}
