using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinPoint : MonoBehaviour {

    public string nextLevel;
    public int enemy =10;
    public int scoreValue = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameOver")
        {
            if (Inventory.Refrence.enemy >= 10)
            {
                ScoreManager.score += scoreValue;
                //Application.LoadLevel("WIN");
                SceneManager.LoadScene("WIN");
            }
        }
    }
}
