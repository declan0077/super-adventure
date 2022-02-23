//Script Created and Owned by Declan Cullen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourBar : MonoBehaviour
{
    //Reference to the player
    public object Player;
    //Reference to the Slider
    public Slider Slider;
    //Reference to the Text
    public Text text;

    public void SetmaxArmour(int Armour)
    {
        Slider.maxValue = Armour;
        Slider.value = Armour;
    }
    public void SetArmour(int Armour)
    {
        Slider.value = Armour;
    }
    public void UpdateText(int Armour)
    {
        text.text = Armour.ToString();
    }
}
