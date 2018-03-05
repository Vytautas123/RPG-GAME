using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private int enemyLeft = 2;

    public void EnemyHasDied()
    {
       // enemyLeft--;

        if (enemyLeft == 0)
        {

            enemyLeft--;
        }
    }

    public void EnemyHasAppeared()
    {
      
        SceneManager.LoadScene("WIN");
    }
}
