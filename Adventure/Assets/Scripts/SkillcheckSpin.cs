using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillcheckSpin : MonoBehaviour
{
    public bool onSuccessArea;
    public bool flipflop;
    public float speed = 10f;
    public Player playerScript;
    public Enemy enemyScript;
    public GameObject blockSkillcheck;
 
    // Update is called once per frame
    void Update()
    {
       
        if (flipflop) transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        else transform.Rotate(new Vector3(0, 0, -1 * (speed * Time.deltaTime)));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onSuccessArea)
            {
                playerScript.HitRangedAttack();
                Debug.Log("Success!");
            }
            else
            {
                playerScript.MissRangedAttack();
                Debug.Log("Missed!");

            }
            flipflop = !flipflop;
        }

       
  
    }
   
}
