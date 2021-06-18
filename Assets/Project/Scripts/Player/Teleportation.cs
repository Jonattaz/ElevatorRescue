using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    // GameObjects
    public GameObject[] doors;
    public GameObject player;
    public GameObject[] bones;
    public GameObject boss;
    public GameObject endGame;

    // Int
    private int random;
    private int bonesLenght;


    // String
    public string nextSceneName;


    // bool
    private bool active = false;
    private bool sound = false;

    // Update is called once per frame
    void Update()
    {
        // When the button is unpressed the telport stop work
        if (Input.GetKeyUp(KeyCode.G))
        { 
           active = false;
            if (sound)
            {
                SoundManager.PlaySound("doorOpen");
                sound = false;
            }

        }


        // When the button is pressed the telport starts work
        if (Input.GetKeyDown(KeyCode.G))
        {
            active = true;
            
        }

        if (boss == null)
        {
            endGame.gameObject.SetActive(true);
        }

        

    }


    // Controls the teleport action
    IEnumerator Teleport()
    {
        // Makes the player teleport to a random door
        random = Random.Range(0, doors.Length);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = new Vector2(doors[random].transform.position.x,
            doors[random].transform.position.y);

    }


    private void Start()
    {
        
        bonesLenght = (bones.Length - 1) - (bones.Length - 1);
    }


    /* Activates the teleport when player collide with an object who has the tag
     * InteractiveDoor
    */
    private void OnTriggerStay2D(Collider2D collision)
    {


            if (collision.gameObject.CompareTag("InteractiveDoor") && active)
            {
                sound = true;
                StartCoroutine(Teleport());
                
            }



        if (collision.gameObject.CompareTag("SceneLoaderDoor") && active)
            {
                SceneManager.LoadScene(nextSceneName);
                SoundManager.PlaySound("doorOpen");
            }

        
        
            if (collision.gameObject.CompareTag("BoneDoor") && bonesLenght <= bones.Length - 1 && active)
            {
                if (bones[bonesLenght].gameObject != null)
                {
                     sound = true;
                     bones[bonesLenght].gameObject.SetActive(true);
                     bonesLenght += 1;
                }
            }
        

        if (collision.gameObject.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(nextSceneName);
        }

    }   


}















