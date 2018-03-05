using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interacteble focus;
    
    Camera cam;
    PlayerMotor motor;

    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;

    private bool mRunning = false;
    // Use this for initialization
   
    void Start () {

        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();

        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                //  FindObjectOfType<AudioManager>().Play("On_My_Way");
               
                motor.MoveToPoint(hit.point);
               
                RemoveFocus();
                mNavMeshAgent.destination = hit.point;
                
            }
           
        }
       
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
           
            mRunning = false;
            FindObjectOfType<AudioManager>().Play("test");
        }
        else
        {

            mRunning = true;

        }

        mAnimator.SetBool("running", mRunning);

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               Interacteble interacteble= hit.collider.GetComponent<Interacteble>();
                
                FindObjectOfType<AudioManager>().Play("gun");
                if (interacteble != null)
                {
                     SetFocus(interacteble);
                   
                }

                if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
                {

                    mRunning = true;
                }


              
            }
        }

       
    }
    void SetFocus(Interacteble newFocus)
    {
        if(newFocus != focus)
        {
            
            if (focus!=null)
                focus.OnDefocused();
           
            focus = newFocus;
            motor.FollowTarge(newFocus);
        }

        
        newFocus.OnFocus(transform);
       
    }
    void RemoveFocus()
    {
        if(focus!=null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

}
