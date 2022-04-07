using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPress : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown() 
    {
        animator.Play("Exit_PressedDown", -1, 0f);
        Application.Quit();
    }
}
