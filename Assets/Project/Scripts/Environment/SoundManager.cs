using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerDeath, playerFootSteps, playerShoot, playerBone,
        enemiesDamage, enemiesShoot, doorOpen, elevadorOn, bossGranade, bossShoot;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        bossGranade = Resources.Load<AudioClip>("bossGranade");
        bossShoot = Resources.Load<AudioClip>("bossShoot");
        doorOpen = Resources.Load<AudioClip>("doorOpen");
        elevadorOn = Resources.Load<AudioClip>("elevadorOn");
        enemiesDamage = Resources.Load<AudioClip>("enemiesDamage");
        enemiesShoot = Resources.Load<AudioClip>("enemiesShoot");
        playerBone = Resources.Load<AudioClip>("playerBone");
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerFootSteps = Resources.Load<AudioClip>("playerFootSteps");
        playerShoot = Resources.Load<AudioClip>("playerShoot");

        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "playerShoot":
                audioSrc.PlayOneShot(playerShoot);
                break;
            case "playerFootSteps":
                audioSrc.PlayOneShot(playerFootSteps);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath);
                break;
            case "playerBone":
                audioSrc.PlayOneShot(playerBone);
                break;
            case "enemiesShoot":
                audioSrc.PlayOneShot(enemiesShoot);
                break;
            case "enemiesDamage":
                audioSrc.PlayOneShot(enemiesDamage);
               break;
            case "elevadorOn":
                audioSrc.PlayOneShot(elevadorOn);
               break;
            case "doorOpen":
                audioSrc.PlayOneShot(doorOpen);
               break;
            case "bossShoot":
                audioSrc.PlayOneShot(bossShoot);
               break;
            case "bossGranade":
                audioSrc.PlayOneShot(bossGranade);
               break;

        }

    }


}











