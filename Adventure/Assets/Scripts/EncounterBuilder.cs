//script created by Declan Cullen


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Riddles
{
    public string Question { get; set; }
    public string CorrectAnwer { get; set; }
    public string WrongAnwer { get; set; }

    public Riddles(string riddleText, string correctAnswer, string wrongAnswer)
    {
        Question = riddleText;
        CorrectAnwer = correctAnswer;
        WrongAnwer = wrongAnswer;
    }
}
public class EncounterBuilder : MonoBehaviour
{
    private int scenarioNum;
    public TMP_Text scenario;
    public TMP_Text Option1;
    public TMP_Text Option2;
    public Image Scene;
    public int randomRiddleNumber;


    // Start is called before the first frame update
    void Start()
    {
        scenarioNum = Random.Range(1, 5);
        switch (scenarioNum)
        {
            case 1:
                scenario.text = ("The bridge ahead is broken and can not be walked across");
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
                scenario.text = ("A man in a mask challenges you to a task");
                Option1.text = ("Accept his Challenge");
                Option2.text = ("Continue Walking");
                Scene = Resources.Load<Image>("Assets/Dagger");
                break;
            case 5:

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
                Riddle();
                break;
            case 5:
                if (randomRiddleNumber ==  1 || randomRiddleNumber == 2 || randomRiddleNumber == 4)
                {
                    PlayerStats.Charisma += 1;
                    PlayerStats.Intelligence += 1;
                    PlayerStats.Strength += 1;
                    PlayerStats.Constitution += 1;
                    Travel();
                } else
                {
                    Debug.Log("Wrong Answer");
                    Travel();
                }
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
                Travel();
                break;
            case 5:
                if (randomRiddleNumber == 3 || randomRiddleNumber == 5)
                {
                    PlayerStats.Charisma += 1;
                    PlayerStats.Intelligence += 1;
                    PlayerStats.Strength += 1;
                    PlayerStats.Constitution += 1;
                    Travel();
                }
                else
                {
                    Debug.Log("Wrong Answer");
                    Travel();
                }
                break;


        }
    }
    public void Travel()
    {
        if (PlayerStats.Level <= 3)
        {
            SceneManager.LoadScene("Forest");
        }
        if (PlayerStats.Level >= 3 && PlayerStats.Level < 5)
        {
            SceneManager.LoadScene("Beach");
        }
        if (PlayerStats.Level >= 5 && PlayerStats.Level < 7)
        {
            SceneManager.LoadScene("DarkForest");
        }
        if (PlayerStats.Level >= 7 && PlayerStats.Level < 10)
        {
            SceneManager.LoadScene("Castle");
        }
    }



    public void Riddle()
    {
        scenarioNum = 5;

        Riddles[] riddleList = new Riddles[5];

        riddleList[0] = new Riddles("What's the name of a Knight's body armor, that covers the feet?", "Sabaton ", "Chausses");
        riddleList[1] = new Riddles("What was King Arthur's sword called?", "Excalibur", "Galatine");
        riddleList[2] = new Riddles("What was Fergus Mac Róich's sword called?", "Caladbolg", "Gáe Bulg");
        riddleList[3] = new Riddles("What was King Charlemagne sword called?", "Joyeuse", "Curtana");
        riddleList[4] = new Riddles("Where did Oisín go?", "Tir na nÓg", "Dubnos");

         randomRiddleNumber = Random.Range(1, 5);

        switch (randomRiddleNumber)
        {
            case 1:
                scenario.text = riddleList[0].Question;
                Option1.text = riddleList[0].CorrectAnwer;
                Option2.text = riddleList[0].WrongAnwer;
                break;
            case 2:
                scenario.text = riddleList[1].Question;
                Option1.text = riddleList[1].CorrectAnwer;
                Option2.text = riddleList[1].WrongAnwer;
                break;
            case 3:
                scenario.text = riddleList[2].Question;
                Option2.text = riddleList[2].WrongAnwer;
                Option1.text = riddleList[2].CorrectAnwer;
              
                break;
            case 4:
                scenario.text = riddleList[3].Question;
                Option1.text = riddleList[3].CorrectAnwer;
                Option2.text = riddleList[3].WrongAnwer;
                break;
            case 5:
                scenario.text = riddleList[4].Question;
                Option2.text = riddleList[4].WrongAnwer;
                Option1.text = riddleList[4].CorrectAnwer;
                break;
            default:
                Debug.Log("Defaulted");
                break;
            
        }


    }

  

    }

