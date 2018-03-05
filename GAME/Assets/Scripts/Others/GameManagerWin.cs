using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerWin : MonoBehaviour {

    public static GameManagerWin instance = null;

    public GameObject youWinText;

     void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            
            Destroy(gameObject);
    }

    public void Win()
    {
        youWinText.SetActive(true);
    }

   
}
