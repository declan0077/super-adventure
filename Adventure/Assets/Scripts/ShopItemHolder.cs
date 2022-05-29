using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ShopItems", menuName = "New Shop Item")]
public class ShopItemHolder : ScriptableObject
{
    public string itemName;
    public int itemCost;
    public string itemDescription;
    public Sprite itemImage;

}
