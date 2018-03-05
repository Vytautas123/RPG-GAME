  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private bool mRunning = false;


    private bool die = false;  /// testas 
    // Use this for initialization
    void Start () {


        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
	}
	
	// Update is called once per frame
	void Update () {

        if (die == true)
        {
            return;
        }

        if (target != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);
        

       
       
        if (distance <= lookRadius)
        {
      

            agent.SetDestination(target.position);            
            mAnimator.SetTrigger("attack");           
            if (distance<= agent.stoppingDistance)
            {
               
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                
                if (targetStats != null)
                {
                   
                    combat.Attack(targetStats);
                    
                }
                FaceTarget();
                
            }
            
        }
       
        }
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            
            mRunning = false;
        }
        else
        {
            mRunning = true;
           
        }      
        mAnimator.SetBool("running", mRunning);
    }

    void FaceTarget()
    {
       
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
   
}
