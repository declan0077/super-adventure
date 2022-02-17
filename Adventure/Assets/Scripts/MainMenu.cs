using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject playerCreation;
    public GameObject menuButtons;

    public Button confirmPlayerName;
    public InputField userInput;

    public static string playerName;

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
        playerName = userInput.text;
        SceneManager.LoadScene("Story1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoBack()
    {
        playerCreation.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void CreateCharacter()
    {
        playerCreation.SetActive(true);
        menuButtons.SetActive(false);
    }
}
