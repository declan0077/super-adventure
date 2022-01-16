using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static public int Gold = 20;
    static public int XP = 0;
    static public int Level = 1;
    static public int LevelupCost = 50;
    static public int statupgrade = 0;
    static public bool Levelup = false;


    //Player Stats

    static public int Strength = 0;
    static public int Agility = 0;
    static public int Constitution = 0;
    static public int Intelligence = 0;
    static public int Charisma = 0;

    //Shield

    static public int Shield = 0;

    //Sword

    static public int Sword = 0;

    //Dropdown

    public Dropdown Shieldlist;

    public void ShieldChange()
    {
        Shieldlist.value = Shield;
        ShieldCheck();
    }

    public void Start()
    {
        
    }
    public static void Check()
    {
        if(XP >= LevelupCost)
        {
            Level += 1;
            LevelupCost += 100;
            statupgrade += 1;
            Debug.Log("levelup");
            Levelup = true;
            XP = 0;
        }


    }

    public static void ShieldCheck()
    {
        switch(Shield)
        {
            case 1:
                Debug.Log("Round Shield");
                break;
            case 2:
                Debug.Log("Kite Shield");
                break;
            case 3:
                Debug.Log("Tower Shield");
               break;
            default:
            break;
        }
    }
}
