using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPistol : MonoBehaviour
{
    // GameObject
    public GameObject gun;
    public GameObject bullet;

    // Transform
    public Transform shootPoint;

    // Float
    public float bullettSpeed;
    public float fireRate;
    float readyForNextShot;

    //animador
    public Animator Animator;


    // Update is called once per frame
    void Update()
    {
        ShootKey();
    }

    // Instantiate the bullet
    private void Shoot()
    {
        GameObject bulletInst = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        bulletInst.GetComponent<Rigidbody2D>().AddForce(bulletInst.transform.right * bullettSpeed);
        Destroy(bulletInst, 0.7f);

    }


    // Controls the key to shoot when a button is pressed 
    private void ShootKey()
    {

        if (Input.GetKeyDown(KeyCode.H) && gameObject != null)
        {
            SoundManager.PlaySound("playerShoot");
            // Ativar a animação do tiro
            if (Time.time > readyForNextShot)
            {
                readyForNextShot = Time.time + 1 / fireRate;
                Animator.SetTrigger("pew pew");
                Shoot();
            }

        }
    }


}










