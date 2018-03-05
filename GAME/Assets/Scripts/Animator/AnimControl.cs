using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimControl : MonoBehaviour {

    private Animator mAnimator;
    // Use this for initialization
    
    void Start () {
        mAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(1))
        {
            mAnimator.SetTrigger("attack");            
          
        }

    }
}
