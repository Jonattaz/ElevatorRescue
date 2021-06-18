using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{

    // When the player collide with the pencil ammo, he collect it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("playerBone");
            BoneText.BoneAmount += 1;
            Destroy(gameObject);
        }
    }

}
