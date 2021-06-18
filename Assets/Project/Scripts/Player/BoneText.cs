using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoneText : MonoBehaviour
{
    // Bone text
    public static Text text;

    // BoneAmout the quantity of bones
    public static int BoneAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        BoneController();

    }

    // Controls the UI bone text
    private void BoneController()
    {
        if (BoneAmount > 0)
        {
            text.text = "Ossos: " + BoneAmount;
        }
        else
        {
            text.text = "Ossos: 0";
            BoneAmount = 0;
        }
    }

}
