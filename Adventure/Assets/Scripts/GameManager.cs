//script created by Dane Donaldson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool playerTurn = true;
    public bool enemyTurn = false;


    //Text Displayed if it's the Players turn.
    [SerializeField] private TMP_Text p_turnText;

    //Text Displayed if it's the Enemys turn.
    [SerializeField] private TMP_Text e_turnText;


    [SerializeField] private GameObject playerChoiceUI;

    public GameObject abilityTutorial;
    public bool tutorialActive = false;

    // Update is called once per frame
    void Update()
    {
        //Fire2 = left alt
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShowTutorial();
        }

     
        if (playerTurn && !enemyTurn)
        {
            p_turnText.enabled = true;
            e_turnText.enabled = false;
            playerChoiceUI.SetActive(true);
        }
        else if (enemyTurn && !playerTurn)
        {
            e_turnText.enabled = true;
            p_turnText.enabled = false;
            playerChoiceUI.SetActive(false);
        }
        else
        {
            p_turnText.enabled = false;
            e_turnText.enabled = false;
        }
    }

    public void ShowTutorial()
    {
        if (!tutorialActive)
        {
            abilityTutorial.SetActive(true);
            tutorialActive = true;
        }
        else if (tutorialActive)
        {
            abilityTutorial.SetActive(false);
            tutorialActive = false;
        }
    }
}
