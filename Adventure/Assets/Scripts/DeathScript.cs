using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{

    
    public TMP_Text Level;
   
    // Start is called before the first frame update
    void Start()
    {
        Level.text = "Over your journey you become this much stronger: " + PlayerStats.Level.ToString();
      

    }

    public void Restartgame()
    {
        PlayerStats.Level = 1;
        PlayerStats.Strength = 0;
        PlayerStats.Constitution = 0;
        PlayerStats.Charisma = 0;
        PlayerStats.Intelligence = 0;
        PlayerStats.Agility = 0;
        PlayerStats.XP = 0;
        PlayerStats.Gold = 0;
        SceneManager.LoadScene("Main Menu");
    }
}
