//script created by Dane Donaldson and Declan Cullen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopBuyingScript : MonoBehaviour
{
    public AudioSource purchaseSound;

    public TMP_Text sword1PriceText;
    public Button sword1Purchase;

    public TMP_Text sword2PriceText;
    public Button sword2Purchase;

    public TMP_Text sword3PriceText;
    public Button sword3Purchase;

    public TMP_Text shield1PriceText;
    public Button shield1Purchase;

    public TMP_Text shield2PriceText;
    public Button shield2Purchase;

    public TMP_Text shield3PriceText;
    public Button shield3Purchase;

    public TMP_Text spell1PriceText;
    public Button spell1Purchase;

    public TMP_Text spell2PriceText;
    public Button spell2Purchase;

    public TMP_Text spell3PriceText;
    public Button spell3Purchase;

    public void Sword1()
    {
        if (PlayerStats.Gold >= 100)
        {
            PlayerStats.Gold -= 100;
            PlayerStats.SwordLevel = 1;
            sword1PriceText.text = "Purchased";
            //Disables Purchase Button, preventing repurchases
            sword1Purchase.enabled = false;
            purchaseSound.Play();
        }
    }
    public void Sword2()
    {
        if (PlayerStats.Gold >= 300)
        {
            PlayerStats.Gold -= 300;
            PlayerStats.SwordLevel = 2;
            sword2PriceText.text = "Purchased";
            sword2Purchase.enabled = false;
            purchaseSound.Play();
        }
    }
    public void Sword3()
    {
        if (PlayerStats.Gold >= 1000)
        {
            PlayerStats.Gold -= 1000;
            PlayerStats.SwordLevel = 3;
            sword3PriceText.text = "Purchased";
            sword3Purchase.enabled = false;
            purchaseSound.Play();
        }
    }
    public void Shield1()
    {
        if (PlayerStats.Gold >= 100)
        {
            PlayerStats.Gold -= 100;
            PlayerStats.ShieldLevel = 1;
            shield1PriceText.text = "Purchased";
            shield1Purchase.enabled = false;
            purchaseSound.Play();
        }
    }
    public void Shield2()
    {
        if (PlayerStats.Gold >= 300)
        {
            PlayerStats.Gold -= 300;
            PlayerStats.ShieldLevel = 2;
            shield2PriceText.text = "Purchased";
            shield2Purchase.enabled = false;
            purchaseSound.Play();
        }
    }
    public void Shield3()
    {
        if (PlayerStats.Gold >= 1000)
        {
            PlayerStats.Gold -= 1000;
            PlayerStats.ShieldLevel = 3;
            shield3PriceText.text = "Purchased";
            shield3Purchase.enabled = false;
            purchaseSound.Play();
        }
    }
    //Blue Spell
    public void Spell1()
    {
        if (PlayerStats.Gold >= 100)
        {
            PlayerStats.Gold -= 100;
            PlayerStats.SpellLevel = 1;
            spell1PriceText.text = "Purchased";
            spell1Purchase.enabled = false;
            purchaseSound.Play();
        }
    }
    //Red Spell
    public void Spell2()
    {
        if (PlayerStats.Gold >= 300)
        {
            PlayerStats.Gold -= 300;
            PlayerStats.SpellLevel = 2;
            spell2PriceText.text = "Purchased";
            spell2Purchase.enabled = false;
            purchaseSound.Play();
        }
    }
    //Green Spell
    public void Spell3()
    {
        if (PlayerStats.Gold >= 1000)
        {
            PlayerStats.Gold -= 1000;
            PlayerStats.SpellLevel = 3;
            spell3PriceText.text = "Purchased";
            spell3Purchase.enabled = false;
            purchaseSound.Play();
        }
    }

}
