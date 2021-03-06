//Script Created and Owned by Dane Donaldson and Declan Cullen


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

    public AudioSource[] swordSwings;

    public int randSoundSelect;

    //Skillcheck Hit Checks

    public bool NormalHit = false;
    public bool CritHit = false;

    void Start()
    {
        nextPos = startPos.position;
        randSoundSelect = Random.Range(0, 2);
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
            swordSwings[randSoundSelect].Play();
        }
        else if (NormalHit == false && CritHit == true)
        {
            Player.CritAttack();
            SkillCheck.SetActive(false);
            Debug.Log("Crit");
            swordSwings[randSoundSelect].Play();
        }
        //Sometimes both Normal and Crit are true. Forcing a Normal Attack during this
        else if (NormalHit == true && CritHit == true)
        {
            Player.normalattack();
            SkillCheck.SetActive(false);
            Debug.Log("NormalAttack");
            swordSwings[randSoundSelect].Play();
        }
        else
        {
            Player.MissAttack();
            SkillCheck.SetActive(false);
            Debug.Log("Missed");
        }

    }
}
