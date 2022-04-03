using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public AudioSource fxMusic;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playFX(AudioClip music, float volume) {
        fxMusic.volume = volume;
        fxMusic.PlayOneShot(music);
    }
}
