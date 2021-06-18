using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityScript : MonoBehaviour
{
   
    public float shootingRange;
    public float HabilityRate = 15f;
    private float nextHabilityTime;
    public Transform player;
    public GameObject hability;
    public GameObject habilityParent;



    void Start()
    {
        //disparar habilidade esfera na direção do game object com tag "Player"
        // Serve para referenciar o transform do objeto que possui a tag player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
      


    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
       
        if (distanceFromPlayer <= shootingRange && nextHabilityTime <Time.time)
        {
            //spawnar a habilidade (esfera) do game object HabilityParent
            //Ativar animação da granada
            SoundManager.PlaySound("bossShoot");
            Instantiate(hability, habilityParent.transform.position, Quaternion.identity); 
            nextHabilityTime = Time.time + HabilityRate;
        }
    }

}
