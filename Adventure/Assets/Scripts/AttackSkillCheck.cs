using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSkillCheck : MonoBehaviour
{
    //Gets the location of the two Postions
    public Transform pos1, pos2;
    //Movement Speed of the skillcheck
    public float speed;
    //The starting postion of the skill check
    public Transform startPos;
    //The location of the next postion
    Vector3 nextPos;
    public Player Player;
    //SkillCheck reference
    public GameObject SkillCheck;


    //Skillcheck Hit Checks

    public bool NormalHit = false;
    public bool CritHit = false;

    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Strike();
        }
        // This creates a flip flop postion system
        if (transform.position== pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
       //This controls where the platfrom is moving to and at what speed
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    public void Strike()
    {
        
        if (NormalHit == true && CritHit == false)
        {
            Player.normalattack();
            SkillCheck.SetActive(false);
            Debug.Log("NormalAttack");
        }
        if (NormalHit == false && CritHit == true)
        {
            Player.CritAttack();
            SkillCheck.SetActive(false);
            Debug.Log("Crit");
        }
        if (NormalHit == false && CritHit == false)
        {
            Player.MissAttack();
            SkillCheck.SetActive(false);
            Debug.Log("Missed");
        }

    }
}
