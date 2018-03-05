using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;


    public Slider heltBar;
    private bool dead = false;
    private Animator mAnimator;

    public GameObject pickupEffect;
    public GameObject enemy;
    public GameObject Player;

    public static GameManagerWin instance = null;

    public int scoreValue = 1;
    void Awake()
    {

        currentHealth = maxHealth;
        mAnimator = GetComponent<Animator>();



    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {

        if (dead == true)
        {
            return;
        }

        // maxHealth = maxHealth-5;
        heltBar.value = maxHealth;
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        heltBar.value = currentHealth;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        
             if (currentHealth <= 0)
                {

                    Die();
                   Instantiate(pickupEffect, transform.position, transform.rotation);
                    Inventory.Refrence.enemy += 1;
            ScoreManager.score += scoreValue;

           // InventoryPL.Refrence.Player += 1;

            FindObjectOfType<AudioManager>().Play("explosion");
            
            Destroy(gameObject);
          //  SceneManager.LoadScene("GameOver");
        }
            


             if (currentHealth >= 0)
         {           
            
            FindObjectOfType<AudioManager>().Play("sword");


        }
                           
    }
 

    public virtual void Die()
    {

        dead = true;
        mAnimator.SetBool("die", true);
        mAnimator.SetBool("running", false);
        mAnimator.SetBool("attack", false);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Destroy(rigidbody);
        Debug.Log(transform.name + " died");
       
    }

}
