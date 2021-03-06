//scripts created by Declan Cullen
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static public int Gold = 0;
    static public int XP = 0;
    static public int Level = 1;
    static public int LevelupCost = 50;
    static public int statupgrade = 0;
    static public bool Levelup = false;
    static public int ShieldLevel;
    static public int ArmourLevel;
    static public int SwordLevel;
    static public int SpellLevel;
    //Checks if the player has seen the goblin storyline
    static public bool GoblinScene = false;
    //Numbers of enemy killed
    static public int GoblinsKilled;
    //Checks if the player has seen the skeleton storyline
    static public bool SkeletonScene = false;
    //Numbers of enemy killed
    static public int SkeletonKilled;
    //Checks if the player has seen the bigedstart storyline
    static public bool BigEdScene = false;
    //Numbers of enemy killed
    static public int OrcKilled;
    //Checks if the player has killed biged
    static public bool BigEdDead = false;
    //Player Stats
    static public int Strength = 0;
    static public int Agility = 0;
    static public int Constitution = 0;
    static public int Intelligence = 0;
    static public int Charisma = 0;

    //Player Appearance
    static public bool Male;
    static public int Race;
    static public Color Skincolour;
    //Human = 1 Elf = 2 Orc = 3 catperson = 4



    //Shield
    static public int Shield = 0;
    //Shield Armour gets applied to the player
    static public int ArmourAmount;

    //Sword

    static public int Sword = 0;


    

    //Keeps the traits running throughout the game
   

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
