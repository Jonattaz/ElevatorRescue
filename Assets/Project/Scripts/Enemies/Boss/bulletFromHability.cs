using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFromHability : MonoBehaviour
{
   
    public Transform player;
    Rigidbody2D bulletFromHabilityRB;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        bulletFromHabilityRB = GetComponent<Rigidbody2D>();

        Vector2 moveDir = (player.transform.position - transform.position).normalized * 3;
        // Tentei randomizar a velocidade do projetil que spawna após a explosão da habili
        // dade porém não funcionou
        bulletFromHabilityRB.velocity = new Vector2 (Random.Range(-1, moveDir.x * 5 ), 
            Random.Range( -1, moveDir.y * 5 ));
       
        //bulletFromHabilityRB.velocity = new Vector2(moveDir.x * 3, moveDir.y * 3);

        Destroy(this.gameObject, 2f);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (SceneController.cheat == false)
        {
            if (collision.gameObject.CompareTag("Player") && collision.gameObject.activeInHierarchy)
            {
                HeartSystem.life -= 1;
                Destroy(gameObject);

                if (HeartSystem.life == 0)
                {
                    player.gameObject.SetActive(false);
                    HeartSystem.life = 0;
                }
            }
        }
    }
}

