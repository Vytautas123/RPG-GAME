using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endscript : MonoBehaviour {

	public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
