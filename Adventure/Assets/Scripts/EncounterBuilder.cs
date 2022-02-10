using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EncounterBuilder : MonoBehaviour
{
    private int scenarioNum;
    public TMP_Text scenario;
    public TMP_Text Option1;
    public TMP_Text Option2;
    public Image Scene;

    // Start is called before the first frame update
    void Start()
    {
        scenarioNum = Random.Range(1, 4);
        switch (scenarioNum)
        {
            case 1:
                scenario.text = ("A broken down bridge is preventing you from travelling");
                Option1.text = ("Repair the bridge");
                Option2.text = ("Jump across");
                Scene = Resources.Load<Image>("Assets/Bridge");
         
                break;
            case 2:
                scenario.text = ("A merchants cart wheel has broke and it blocking the path");
                Option1.text = ("Help fix the wheel");
                Option2.text = ("Leave It alone");
                Scene = Resources.Load<Image>("Assets/Layer 1");
                break;
            case 3:
                scenario.text = ("While camping you meet a traveller from an antique land");
                Option1.text = ("Listen to his story");
                Option2.text = ("Steal his stuff");
                Scene = Resources.Load<Image>("Assets/Dagger");
                
                break;
            case 4:
                scenario.text = ("Test scenario");
                Option1.text = ("Option1");
                Option2.text = ("Option2");
                Scene = Resources.Load<Image>("Assets/shield");
                break;
        }
    }
    public void Reward1()
    {
        switch (scenarioNum)
        {
            case 1:
                PlayerStats.Constitution += 1;
                Travel();
             break;
            case 2:
                PlayerStats.Charisma += 1;
                Travel();
                break;
            case 3:
                PlayerStats.Charisma += 4;
                PlayerStats.Intelligence += 4;
                Travel();
                break;
            case 4:

                break;
        }
    }
    public void Reward2()
    {
            switch (scenarioNum)
            {
            case 1:
                PlayerStats.Strength += 1;
                Travel();
                break;
            case 2:
                PlayerStats.Charisma -= 1;
                Travel();
                break;
            case 3:
                PlayerStats.Gold += 1000;
                PlayerStats.Intelligence += 1;
                Travel();
                break;
            case 4:

                break;
        }
    }
    public void Travel()
    {
        if (PlayerStats.Level <= 3)
        {
            SceneManager.LoadScene("Forest");
        }
        if (PlayerStats.Level > 3 && PlayerStats.Level < 5)
        {
            SceneManager.LoadScene("Beach");
        }
    }
}
