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
    public Button confirmPlayerName;
    public InputField userInput;
    public GameObject credits;

    public GameObject gameTitle;
    public GameObject menuBackground;

    public static string playersName;

    public ChooseSex genderScript;

    public string[] maleNames;
    public string[] femaleNames;
 

    // Start is called before the first frame update
    void Start()
    {
        confirmPlayerName.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        menuBackground.SetActive(true);
        gameTitle.SetActive(true);
        credits.SetActive(false);
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
        menuBackground.SetActive(false);
        gameTitle.SetActive(false);
       
    }

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


    }
