using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static public int Gold = 10000;
    static public int XP = 0;
    static public int Level = 1;
    static public int LevelupCost = 50;
    static public int statupgrade = 0;
    static public bool Levelup = false;
    static public int ShieldLevel;
    static public int SwordLevel;
    static public int SpellLevel;
    static public bool GoblinScene = false;
    static public int GoblinsKilled;
    static public bool SkeletonScene = false;
    static public int SkeletonKilled;
    //Player Stats

    static public int Strength = 0;
    static public int Agility = 0;
    static public int Constitution = 0;
    static public int Intelligence = 0;
    static public int Charisma = 0;

    //Shield

    static public int Shield = 0;
    //Shield Armour gets applied to the player
    static public int ArmourAmount;

    //Sword

    static public int Sword = 0;

    //Dropdown

    public Dropdown Shieldlist;

  
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
                if (Gold >= 10 && ShieldLevel < 1)
                {
                    Gold -= 10;
                    Debug.Log("You bought a Round Shield");
                    ShieldLevel = 1;
                    ArmourAmount = 5;
                    break;
                }
                else
                {
                    Debug.Log("Not enough money or you have better");
                    break;
                }
            case 2:
                if (Gold >= 100 && ShieldLevel < 2)
                {
                    Gold -= 100;
                    Debug.Log("You bought a Kite Shield");
                    ShieldLevel = 2;
                    ArmourAmount = 15;
                    break;
                }
                else
                {
                    Debug.Log("Not enough money or you have better");
                    break;
                }
            case 3:
                if (Gold >= 1000 && ShieldLevel < 3)
                {
                    Gold -= 1000;
                    Debug.Log("You bought a Tower Shield");
                    ShieldLevel = 3;
                    ArmourAmount = 30;
                    break;
                }
                else
                {
                    Debug.Log("Not enough money or you have better");
                    break;
                }
            default:
                Debug.Log("Round Shield");
                break;
        }
    }
}
