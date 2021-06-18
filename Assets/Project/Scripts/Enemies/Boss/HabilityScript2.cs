using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityScript2 : MonoBehaviour
{

    public float habilitySpeed;
    GameObject target;
    Rigidbody2D habilityRB;
    public GameObject bulletFromHability;
    public GameObject hability;
    


    void Start()
    {
        habilityRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("FeetPlayer");

        //chama a função "DestroyHability"
        StartCoroutine(DestroyHability());

    }

    void Update()
    {           

        Vector2 moveDir = (target.transform.position - transform.position).normalized * habilitySpeed;
        habilityRB.velocity = new Vector2(moveDir.x * 3, moveDir.y * 3);

    }

    IEnumerator DestroyHability()
    {
        //tempo de destruição//explosão da habilidade
        float tempo = 2f;
        Destroy(this.gameObject, 3f);

       yield return new WaitForSeconds(tempo);

        // spawnar "tiros" após a explosão/destruição da habilidade
        SoundManager.PlaySound("bossGranade");
        Instantiate(bulletFromHability, hability.transform.position, Quaternion.identity);
        Instantiate(bulletFromHability, hability.transform.position, Quaternion.identity);
        Instantiate(bulletFromHability, hability.transform.position, Quaternion.identity);
    
    }


   private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if (SceneController.cheat == false) 
        {

            if (collision.gameObject.CompareTag("Player") && collision.gameObject.activeInHierarchy)
            {
                HeartSystem.life -= 1;
                Destroy(gameObject);

                if (HeartSystem.life == 0)
                {
                    target.gameObject.SetActive(false);
                    HeartSystem.life = 0;
                }
            }
        }

    }
}
