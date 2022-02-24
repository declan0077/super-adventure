using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillcheckHit : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {

            collision.gameObject.GetComponentInParent<SkillcheckSpin>().onSuccessArea = true;

        }
        else
        {

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {  
            collision.gameObject.GetComponentInParent<SkillcheckSpin>().onSuccessArea = false;
    }
}
