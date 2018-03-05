
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesOver : MonoBehaviour {

    public string nextLevel;
    public int Player = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WinPoint")
        {
            if (InventoryPL.Refrence.Player == 1)
            {
                //Application.LoadLevel("WIN");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
