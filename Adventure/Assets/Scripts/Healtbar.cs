using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healtbar : MonoBehaviour
{
    //Reference to the player
    public object Player;
    //Reference to the Slider
    public Slider Slider;
    //Reference to the Text
    public Text text;

    public void setmaxhealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }
    public void sethealth(int health)
    {
        Slider.value = health;
    }
    public void UpdateText(int health)
    {
        text.text = health.ToString();
    }
}
