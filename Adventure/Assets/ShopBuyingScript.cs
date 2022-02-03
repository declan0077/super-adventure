using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuyingScript : MonoBehaviour
{
 public void Sword1()
    {
        if (PlayerStats.Gold >= 100)
        {
            PlayerStats.Gold -= 20;
            PlayerStats.SwordLevel = 1;
        }
    }
    public void Sword2()
    {
        if (PlayerStats.Gold >= 300)
        {
            PlayerStats.Gold -= 300;
            PlayerStats.SwordLevel = 2;
        }
    }
    public void Sword3()
    {
        if (PlayerStats.Gold >= 1000)
        {
            PlayerStats.Gold -= 1000;
            PlayerStats.SwordLevel = 3;
        }
    }
    public void Shield1()
    {
        if (PlayerStats.Gold >= 100)
        {
            PlayerStats.Gold -= 20;
            PlayerStats.ShieldLevel = 1;
        }
    }
    public void Shield2()
    {
        if (PlayerStats.Gold >= 300)
        {
            PlayerStats.Gold -= 300;
            PlayerStats.ShieldLevel = 2;
        }
    }
    public void Shield3()
    {
        if (PlayerStats.Gold >= 1000)
        {
            PlayerStats.Gold -= 1000;
            PlayerStats.ShieldLevel = 3;
        }
    }
    public void Spell1()
    {
        if (PlayerStats.Gold >= 100)
        {
            PlayerStats.Gold -= 100;
            PlayerStats.SpellLevel = 1;
        }
    }
    public void Spell2()
    {
        if (PlayerStats.Gold >= 300)
        {
            PlayerStats.Gold -= 300;
            PlayerStats.SpellLevel = 3;
        }
    }
    public void Spell3()
    {
        if (PlayerStats.Gold >= 1000)
        {
            PlayerStats.Gold -= 1000;
            PlayerStats.SpellLevel = 3;
        }
    }

}
