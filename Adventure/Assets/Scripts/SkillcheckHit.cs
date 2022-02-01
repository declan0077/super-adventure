using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillcheckHit : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {

            collision.gameObject.GetComponentInParent<SkillcheckSpin>().onSuccessArea = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            collision.gameObject.GetComponentInParent<SkillcheckSpin>().onSuccessArea = false;
        
        }
    }
}
