////script created by Dane Donaldson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    //GameObjects
    public GameObject SwordShop;
    public GameObject ShieldShop;
    public GameObject SpellShop;
    public GameObject ShopBody;
 

    //What to do when Shields pressed
    public void Shield()
    {
        ShieldShop.SetActive(true);
        SwordShop.SetActive(false);
        SpellShop.SetActive(false);
        ShopBody.SetActive(true);
    }
    //What to do when Swords pressed
    public void Sword()
    {
        ShieldShop.SetActive(false);
        SwordShop.SetActive(true);
        SpellShop.SetActive(false);
        ShopBody.SetActive(true);
    }
    //What to do when magic pressed
    public void Magic()
    {
        ShieldShop.SetActive(false);
        SwordShop.SetActive(false);
        SpellShop.SetActive(true);
        ShopBody.SetActive(true);
    }
    //What to do when shop is closed
    public void Close()
    {
        ShieldShop.SetActive(false);
        SwordShop.SetActive(false);
        SpellShop.SetActive(false);
        ShopBody.SetActive(false);
    }
}
