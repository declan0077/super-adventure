using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillcheckHit : MonoBehaviour
{

    public SkillcheckSpin based;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {

            SkillcheckSpin based = collision.GetComponent<SkillcheckSpin>();
            collision.gameObject.GetComponentInParent<SkillcheckSpin>().onSuccessArea = true;

        }
        else
        {

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {   if (collision.gameObject.CompareTag("Arrow"))
        {

            based.gameObject.GetComponentInParent<SkillcheckSpin>().onSuccessArea = false;
        }
        else
        {

        }
    }
}
