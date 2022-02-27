using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillcheckHit : MonoBehaviour
{
    public SkillcheckSpin successAreaCheck;

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dial")
        {
            successAreaCheck.onSuccessArea = true;
        }
       
    }

    public void OnTriggerExit2D(Collider2D collision)
    {   if (collision.gameObject.name == "Dial")
        {

            successAreaCheck.onSuccessArea = false;
        }
       
    }
}
