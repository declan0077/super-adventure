using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public Player Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Box)
    {
        if (Player.attacking == true && Box.gameObject.CompareTag("Enemy") == true)
        {
            
        }
    }
}
