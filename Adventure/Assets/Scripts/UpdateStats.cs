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
        if(PlayerMoney.statupgrade >= 1)
        {
            PlayerMoney.Strength += 1;
            PlayerMoney.statupgrade -= 1;
            SkillPointCheck();
        }
        else
        {
            PlayerMoney.Levelup = false;
        }
    }
    public void LevelUpAgility()
    {
        if (PlayerMoney.statupgrade >= 1)
        {
            PlayerMoney.Agility += 1;
            PlayerMoney.statupgrade -= 1;
            SkillPointCheck();
        }
        else
        {
            PlayerMoney.Levelup = false;
        }
    }
    public void LevelUpConstitution()
    {
        if (PlayerMoney.statupgrade >= 1)
        {
            PlayerMoney.Constitution += 1;
            PlayerMoney.statupgrade -= 1;
            SkillPointCheck();
        }
        else
        {
            PlayerMoney.Levelup = false;
        }
    }
    public void LevelUpIntelligence()
    {
        if (PlayerMoney.statupgrade >= 1)
        {
            PlayerMoney.Intelligence += 1;
            PlayerMoney.statupgrade -= 1;
            SkillPointCheck();
        }
        else
        {
            PlayerMoney.Levelup = false;
        }
    }
    public void LevelUpCharisma()
    {
        if (PlayerMoney.statupgrade >= 1)
        {
            PlayerMoney.Charisma += 1;
            PlayerMoney.statupgrade -= 1;
            SkillPointCheck();
        }
        else
        {
            PlayerMoney.Levelup = false;
        }
    }
    static void  SkillPointCheck()
    {
       if (PlayerMoney.statupgrade >= 1)
       {
            PlayerMoney.Levelup = false;
       }
        
    }
   public void Baby()
    {
        Debug.Log("waaaaaaaaa");
    }
}
