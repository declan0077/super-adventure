//Script Created and Owned by Dane Donaldson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //UI GameObjects  (Activate and De-activate based on current UI Screen)
    public GameObject playerName;
    public GameObject menuButtons;
    public GameObject playerGender;
    public GameObject credits;
    public GameObject playerPreview;
    public GameObject traits;

    //UI Buttons + Input Fields
    public Button confirmPlayerName;
    public InputField userInput;

    //Strings
    public static string playersName;
    public string[] maleNames;
    public string[] femaleNames;
    
    //Other Scripts
    public ChooseSex genderScript;



    public void PlayGame()
    {
        playersName = userInput.text;
        SceneManager.LoadScene("Story1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoBack()
    {
        playerName.SetActive(false);
        playerGender.SetActive(false);
        menuButtons.SetActive(true);
        credits.SetActive(false);
        playerPreview.SetActive(false);
        traits.SetActive(false);
    }

    public void ChooseName()
    {
        playerName.SetActive(true);
        playerGender.SetActive(false);
    }
    
    public void CharacterGender()
    {
        playerGender.SetActive(true);
        menuButtons.SetActive(false);
        credits.SetActive(false);
        playerPreview.SetActive(true);
    }

    //Randomize Name Function
    public void RandomName()
    {
        if (genderScript.isMale)
        {
            userInput.text = maleNames[Random.Range(0, maleNames.Length - 1)];
        }
        else if (genderScript.isMale == false)
        {
            userInput.text = femaleNames[Random.Range(0, femaleNames.Length - 1)];

        }
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void ChooseTraits()
    {
        traits.SetActive(true);
       
    }
    }
