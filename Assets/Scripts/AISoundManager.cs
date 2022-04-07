using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AISoundManager : MonoBehaviour
{
    public AudioSource fxMusic;
    [SerializeField] Slider sfxSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void update()
    {

    }

    public void playFX(AudioClip music) 
    {
        fxMusic.PlayOneShot(music, (float) sfxSlider.value);
    }
}
