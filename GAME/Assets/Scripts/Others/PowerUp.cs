using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public float multiplier = 1.4f;
    public float duration = 15f;

    public GameObject pickupEffect;

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= multiplier;   //padidina zaideja

       // PlayerStats stats = player.GetComponent<PlayerStats>();
        //stats.maxHealth +=multiplier;

        GetComponent<MeshRenderer>().enabled =false;
        GetComponent<Collider>().enabled =false;



        yield return new WaitForSeconds(duration);

        //stats.maxHealth /= multiplier;

        Destroy(gameObject);
    }
}
