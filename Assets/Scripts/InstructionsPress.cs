using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPress : MonoBehaviour
{
    Animator animator, parentAnimator;
    public GameObject maincamera;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        parentAnimator = maincamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (maincamera.transform.position.x == -17.64f)
        {
            if (Input.anyKey)
            {
                parentAnimator.Play("CloseInstructions");
            }
        }
    }

    void OnMouseDown() 
    {
        animator.Play("Instruction_PressedDown");
        parentAnimator.Play("OpenInstructions");
    }
}
