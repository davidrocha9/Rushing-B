using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainPress : MonoBehaviour
{
    Animator animator, parentAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown() 
    {
        animator.Play("PlayAgain_PressedDown");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
