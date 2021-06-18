using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    // GameObjects
    public GameObject[] hearts;

    // Ints
    public static int life;

    public string respawnSceneName;

    // Start is called before the first frame update
    void Start()
    {
        // Counts the number of hearts 
        life = hearts.Length;

    }

    // Update is called once per frame
    void Update()
    {
        LifeUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* When the player gets shot by a object with the tag EnemyBullet, lose one life
         *  and the number of lifes need to be equal or greater than 0(Zero)
         */

        if (SceneController.cheat == false)
        {
            if (life >= 0 && life <= 4 && collision.gameObject.CompareTag("EnemyBullet")
                || collision.gameObject.CompareTag("BossBullet"))
            {


                SoundManager.PlaySound("playerDeath");
                // Deactivate one heart in the screen
                hearts[life].SetActive(false);


                // When player's lifes get to zero
                if (life == 0)
                {
                    // Restart the number of pencils and the text
                    BoneText.BoneAmount = 0;
                    BoneText.text.text = "Ossos: 0";

                    // Restart the game
                    SceneManager.LoadScene(respawnSceneName);

                    // Restart lifes
                    life = 0;

                }

            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (SceneController.cheat == false)
        {
            if (collision.gameObject.CompareTag("Destroyer"))
            {
                SoundManager.PlaySound("playerDeath");
                SceneManager.LoadScene(respawnSceneName);
                BoneText.BoneAmount = 0;
                BoneText.text.text = "Ossos: 0";
            }
        }
    }

    // Controls the process of gaining one life
    private void LifeUp()
    {
        if (BoneText.BoneAmount >= 10 && life < 5)
        {
           // Restart the pencil text and the number in the scipt
            BoneText.BoneAmount = BoneText.BoneAmount - 10;
            BoneText.text.text = "Ossos: " + BoneText.BoneAmount.ToString();

            // A heart is activated
            if (life >= 0 && life < 5)
            {
                hearts[life].SetActive(true);
                life += 1;
            }
        }
    }


}






