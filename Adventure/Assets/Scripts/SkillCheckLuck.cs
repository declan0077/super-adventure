using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckLuck : MonoBehaviour
{
    public GameObject Skillcheck;
    void Start()
    {
        //for now its just random xd
      float randomluck = Random.Range(0.1f, 1f);
        //Makes the skill check larger or smaller depending on players luck
        Skillcheck.transform.localScale = new Vector3(randomluck, 1, 1);
    }


}
