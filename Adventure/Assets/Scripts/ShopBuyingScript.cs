//script created by Dane Donaldson and Declan Cullen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopBuyingScript : MonoBehaviour
{
    public Weapon shopWeapons;
   

    public AudioSource purchaseSound;

    public TMP_Text itemPriceText;
    public Button itemPurchase;

    private string itemName;
    public  TMP_Text itemDescription;
    private int itemPrice;

    public Image itemImage;

   

    public void Start()
    {
        itemPrice = shopWeapons.itemCost;
        itemPriceText.text = itemPrice.ToString() + " gold";
        itemDescription.text = shopWeapons.itemDescription;
        itemImage.sprite = shopWeapons.itemImage;
       
        
    }

    public void PurchaseItem()
    {
        if (PlayerStats.Gold >= itemPrice )
        {
            PlayerStats.Gold -= itemPrice;
            PlayerStats.SwordLevel = 1;
            itemPriceText.text = "Purchased";
            itemPurchase.enabled = false;
            purchaseSound.Play();
        }
    }
    

}
