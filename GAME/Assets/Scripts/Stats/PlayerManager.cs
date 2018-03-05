using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    #region Singleton

    public static PlayerManager instance;

     void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    bool gameHasEnded = false;
    public float restartDelay = 1f;


    public static int health = 100;
  

    private void Start()
    {
        InvokeRepeating("ReduceHealt", 1, 1);
    }

    void ReduceHealt()
    {
        if (health >= 0)
        {

            //  
        }
        health = health - 0;
        
        if (health <= 0)
        {
         
            
        }
    }
    public void KillPlayer()
    {

        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            SceneManager.LoadScene("GameOver");
            
        }
        
       
    }

    
}
