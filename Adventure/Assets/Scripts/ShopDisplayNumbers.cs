//script created by Declan Cullen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopDisplayNumbers : MonoBehaviour
{
    public TMP_Text GoldNumberDisplay;
    public TMP_Text LevelNumberDisplay;



    void Update()
    {
        GoldNumberDisplay.text = PlayerStats.Gold.ToString() + "G";
        LevelNumberDisplay.text = PlayerStats.Level.ToString();
    }
}
