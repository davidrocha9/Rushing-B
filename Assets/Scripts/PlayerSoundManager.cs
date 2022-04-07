using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioSource playerFX;
    public Player player;
    public AudioClip jetpack;
    Animator animator;
    [SerializeField] Slider sfxSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = player.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.alive)
        {
            Debug.Log("goods");
            playerFX.Pause();
            return;
        }
        
        playerFX.volume = sfxSlider.value;
        if (player.gameObject.transform.position.y < -3.6)
        {
            
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
