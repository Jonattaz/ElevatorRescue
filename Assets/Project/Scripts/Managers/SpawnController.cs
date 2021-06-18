using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    // GameObject
    // Enemies who will activated in the scene
    public GameObject[] enemies;

    // Total number of enemies
    private int enemiesLenght;
    
  
    // Start is called before the first frame update
    void Start()
    {
        enemiesLenght = (enemies.Length - 1) - (enemies.Length - 1);

        InvokeRepeating("SpawnEnemy", 0f, 3f);

    }


    // Controls the moment when the enemies will be activated
    void SpawnEnemy()
    {
        if (EndElevator.enemiesLength > 0 && EndElevator.enemiesLength <= 10 && enemiesLenght <= enemies.Length - 1)
        {
            enemies[enemiesLenght].gameObject.SetActive(true);
            enemiesLenght += 1;

        }
    }


}
