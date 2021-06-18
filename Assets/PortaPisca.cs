using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaPisca : MonoBehaviour
{

    private bool pisca;
    public GameObject player;
    public Animator Animator;
    public bool ativado = false;

private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            Animator.SetBool("pisca", true);
            Debug.Log("Pisca true");
        }
        else{
            Animator.SetBool("pisca", false);
            Debug.Log("Pisca façse");
        }
    }
}
