using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        // Attack Code Goes Here

        Debug.Log("Player Chooses Attack");
    }

    public void Block()
    {
        //Block Code Goes Here

        Debug.Log("Player Chooses Block");
    }

    void Move()
    {
        //Move Code Goes Here

        Debug.Log("Player Chooses Move");
    }

    void Jump()
    {
        //Jump Code Goes Here
        Debug.Log("Player Chooses Jump");
    }
}
