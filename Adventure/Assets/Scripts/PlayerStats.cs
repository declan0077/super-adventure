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
       Shield = Shieldlist.value;
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
            case 0:
                Debug.Log("Empty");
                break;

            case 1:
                if (Gold >= 10)
                {
                    Gold -= 10;
                    Debug.Log("You bought a Round Shield");
                    break;
                }
                else
                {
                    Debug.Log("Not enough money");
                    break;
                }
            case 2:
                if (Gold >= 100)
                {
                    Gold -= 100;
                    Debug.Log("You bought a Kite Shield");
                    break;
                }
                else
                {
                    Debug.Log("Not enough money");
                    break;
                }
            case 3:
                if (Gold >= 1000)
                {
                    Gold -= 1000;
                    Debug.Log("You bought a Tower Shield");
                    break;
                }
                else
                {
                    Debug.Log("Not enough money");
                    break;
                }
            default:
                Debug.Log("Round Shield");
                break;
        }
    }
}
