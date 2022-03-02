//script created by Dane Donaldson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillcheckSpin : MonoBehaviour
{
    public bool onSuccessArea;
    public bool flipflop;
    public float speed = 10f;
    public Player playerScript;
    public GameObject blockSkillcheck;
 
    // Update is called once per frame
    void Update()
    {
       //Rotate the skillcheck dial in a circle motion clockwise or anticlockwise
        if (flipflop) transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        else transform.Rotate(new Vector3(0, 0, -1 * (speed * Time.deltaTime)));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //If skillcheck is succesfully hit...
            if (onSuccessArea)
            {
                playerScript.HitRangedAttack();
                Debug.Log("Success!");
            }
            else
            //if misses
            {
                playerScript.MissRangedAttack();
                Debug.Log("Missed!");

            }
            flipflop = !flipflop;
        }

       
  
    }
   
}
