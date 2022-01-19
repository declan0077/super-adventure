using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHit : MonoBehaviour
{
    public AttackSkillCheck Check;


     
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            Check.NormalHit = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            Check.NormalHit = false;
        }
    }
}
