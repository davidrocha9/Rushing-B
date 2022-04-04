using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScorePress : MonoBehaviour
{
    public GameObject parent;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown() 
    {
        animator.Play("OpenScore", -1, 0f);
    }
}
