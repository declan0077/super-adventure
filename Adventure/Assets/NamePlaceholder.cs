using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlaceholder : MonoBehaviour
{
     public ChooseSex genderScript;
     public Text namePlaceHolder;
   

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //Controls name placeholder depending on what Sex the player chooses.
        if (genderScript.isMale)
        {
            namePlaceHolder.text = "John";
        }
        else 
        {
            namePlaceHolder.text = "Amy";
        }
    }
}
