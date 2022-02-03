using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject SwordShop;
    public GameObject ShieldShop;
    public GameObject SpellShop;
    public GameObject ShopBody;
    void Start()
    {
        
    }
    public void Shield()
    {
        ShieldShop.SetActive(true);
        SwordShop.SetActive(false);
        SpellShop.SetActive(false);
        ShopBody.SetActive(true);
    }
    public void Sword()
    {
        ShieldShop.SetActive(false);
        SwordShop.SetActive(true);
        SpellShop.SetActive(false);
        ShopBody.SetActive(true);
    }
    public void Magic()
    {
        ShieldShop.SetActive(false);
        SwordShop.SetActive(false);
        SpellShop.SetActive(true);
        ShopBody.SetActive(true);
    }
    public void Close()
    {
        ShieldShop.SetActive(false);
        SwordShop.SetActive(false);
        SpellShop.SetActive(false);
        ShopBody.SetActive(false);
    }
}
