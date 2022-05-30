using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ShopItems", menuName = "New Shield")]
public class Shield : ScriptableObject
{
    public string itemName;
    public int itemCost;
    public string itemDescription;
    public Sprite itemImage;
    public int armor;

}
