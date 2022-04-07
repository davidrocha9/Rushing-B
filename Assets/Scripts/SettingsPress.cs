using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPress : MonoBehaviour
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
        if (maincamera.transform.position.y == 10.1f)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Z))
            {
                parentAnimator.Play("CloseSettings");
            }
        }
    }

    void OnMouseDown() 
    {
        parentAnimator.Play("OpenSettings");
    }
}
