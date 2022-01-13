using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    static public int Gold = 20;
    static public int XP = 0;
    static public int Level = 1;
    static public int LevelupCost = 50;
    static public int statupgrade = 0;
    static public bool Levelup = false;
    public void Start()
    {
        
    }
    private void Update()
    {
        if(XP <= LevelupCost)
        {
            Level += 1;
            LevelupCost *= Level;
            statupgrade += 1;
            Debug.Log("levelup");
            Levelup = true;
        }


    }
}
