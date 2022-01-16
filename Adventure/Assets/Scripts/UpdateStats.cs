using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    public Canvas Level;
    public void LevelUpStrength()
    {
        //Maths or Amount to increase this stat by when player levels it up
        if(PlayerStats.statupgrade >= 0)
        {
            PlayerStats.Strength += 1;
            PlayerStats.statupgrade -= 1;
            SkillPointCheck();
            Debug.Log("strengthup");
            Debug.Log(PlayerStats.statupgrade);
        }
        else
        {
            PlayerStats.Levelup = false;
        }
    }
    public void LevelUpAgility()
    {
        if (PlayerStats.statupgrade >= 1)
        {
            PlayerStats.Agility += 1;
            PlayerStats.statupgrade -= 1;
            SkillPointCheck();
        }
        else
        {
            PlayerStats.Levelup = false;
        }
    }
    public void LevelUpConstitution()
    {
        if (PlayerStats.statupgrade >= 1)
        {
            PlayerStats.Constitution += 5;
            PlayerStats.statupgrade -= 1;
            SkillPointCheck();
            Debug.Log("Buff!");
        }
        else
        {
            PlayerStats.Levelup = false;
        }
    }
    public void LevelUpIntelligence()
    {
        if (PlayerStats.statupgrade >= 1)
        {
            PlayerStats.Intelligence += 1;
            PlayerStats.statupgrade -= 1;
            SkillPointCheck();
        }
        else
        {
            PlayerStats.Levelup = false;
        }
    }
    public void LevelUpCharisma()
    {
        if (PlayerStats.statupgrade >= 1)
        {
            PlayerStats.Charisma += 1;
            PlayerStats.statupgrade -= 1;
            SkillPointCheck();
        }
        else
        {
            PlayerStats.Levelup = false;
        }
    }
    static void  SkillPointCheck()
    {
       if (PlayerStats.statupgrade >= 1)
       {
            PlayerStats.Levelup = false;
       }
        
    }
   public void Baby()
    {
        Debug.Log("waaaaaaaaa");
    }
}
