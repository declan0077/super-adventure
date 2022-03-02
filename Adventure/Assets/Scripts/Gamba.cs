//script created by Dane Donaldson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum rpsChoices
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public enum holChoices
{
    NONE,
    HIGHER,
    LOWER
}

public class Gamba : MonoBehaviour
{
    // DICE GAME VARIABLES //////////////////////////////////////////////////////////////////////////////////////

    public bool diceGame = false;

    // ROCK PAPER SCISSORS VARIABLES /////////////////////////////////////////////////////////////////////////


    public bool rpsGame = false;

    public GameObject rpsGameUI;

    public Sprite rock_Sprite, paper_Sprite, scissors_Sprite;
    public Image rps_playerChoiceIMG;
    public Image rps_opponentChoiceIMG;

    public rpsChoices RPSplayerChoice = rpsChoices.NONE;
    public rpsChoices RPSopponentChoice = rpsChoices.NONE;


    // HIGHER OR LOWER VARIABLES /////////////////////////////////////////////////////////////////////////
    public bool holGame = false;
    public holChoices HOLplayerChoice = holChoices.NONE;
    public int holCurrentNumber;
    public int holNewNumber;
    public Text currentNumberText;

    public void Start()
    {
        holCurrentNumber = 50;
        currentNumberText.text = holCurrentNumber.ToString();
    }

    public void Update()
    {
        if (rpsGame)
        {
            rpsGameUI.SetActive(true);
        }
        else
        {
            rpsGameUI.SetActive(false);
        }


        if (holGame)
        {
            
        }
    }


    public void runDiceGame()
    {

    }

    public void RPSGame()
    {
        rpsGame = true;
        
    }

    public void SetRPSChoices(rpsChoices gameChoices)
    {
        switch (gameChoices)
        {
            case rpsChoices.ROCK:
                RPSplayerChoice = rpsChoices.ROCK;
                rps_playerChoiceIMG.sprite = rock_Sprite;
               
                break;
            case rpsChoices.PAPER:
                RPSplayerChoice = rpsChoices.PAPER;
                rps_playerChoiceIMG.sprite = paper_Sprite;
               
                break;
            case rpsChoices.SCISSORS:
                RPSplayerChoice = rpsChoices.SCISSORS;
                rps_playerChoiceIMG.sprite = scissors_Sprite;
               
                break;
        }
        SetRPSOpponentChoice();
        RPSWinner();
    }

        public void SetRPSOpponentChoice(){

            int random = Random.Range(0, 3);

            switch (random)
            {
                case 0:
                    RPSopponentChoice = rpsChoices.ROCK;
                    rps_opponentChoiceIMG.sprite = rock_Sprite;
                    break;
                case 1:
                    RPSopponentChoice = rpsChoices.PAPER;
                    rps_opponentChoiceIMG.sprite = paper_Sprite;
                    break;
                case 2:
                    RPSopponentChoice = rpsChoices.SCISSORS;
                    rps_opponentChoiceIMG.sprite = scissors_Sprite;
                    break;
            }

     
        }

        public void RPSWinner(){
            
        if(RPSplayerChoice == RPSopponentChoice)
        {
            Debug.Log("Draw");
            return;
        }

        if(RPSplayerChoice == rpsChoices.PAPER && RPSopponentChoice == rpsChoices.ROCK)
        {
            Debug.Log("Player Wins!");
            return;
        }

        if(RPSplayerChoice == rpsChoices.ROCK && RPSopponentChoice == rpsChoices.PAPER)
        {
            Debug.Log("Player Wins!");
            return;
        }

        if(RPSplayerChoice == rpsChoices.SCISSORS && RPSopponentChoice == rpsChoices.PAPER)
        {
            Debug.Log("Player Wins!");
            return;
        }

        if (RPSplayerChoice == rpsChoices.ROCK && RPSopponentChoice == rpsChoices.PAPER)
        {
            Debug.Log("Player Loses!");
            return;
        }
        if (RPSplayerChoice == rpsChoices.PAPER && RPSopponentChoice == rpsChoices.SCISSORS)
        {
            Debug.Log("Player Loses!");
            return;
        }
        if (RPSplayerChoice == rpsChoices.SCISSORS && RPSopponentChoice == rpsChoices.ROCK)
        {
            Debug.Log("Player Loses!");
            return;
        }
      
    }

    public void SetHOLOpponentChoice()
    {
        int random = Random.Range(0, 200);
        holNewNumber = random;
        currentNumberText.text = holNewNumber.ToString();
        
        Debug.Log(holNewNumber);
    }

    public void SetHOLChoices(holChoices gameChoices)
    {
       


        switch (gameChoices)
        {
            case holChoices.HIGHER:
                HOLplayerChoice = holChoices.HIGHER;
                break;
            case holChoices.LOWER:
                HOLplayerChoice = holChoices.LOWER;
                break;
        }
        SetHOLOpponentChoice();
        HOLWinner();
        holCurrentNumber = holNewNumber;

    }


    public void HOLWinner()
    {
        //Win Conditions
        if (HOLplayerChoice == holChoices.HIGHER && holNewNumber > holCurrentNumber)
        {
            Debug.Log("Player Wins");
        }
        if (HOLplayerChoice == holChoices.LOWER && holNewNumber < holCurrentNumber)
        {
            Debug.Log("Player Wins");
        }
        //Lose Conditions
        if (HOLplayerChoice == holChoices.HIGHER && holNewNumber < holCurrentNumber)
        {
            Debug.Log("Player Loses");
        }
        if (HOLplayerChoice == holChoices.LOWER && holNewNumber > holCurrentNumber)
        {
            Debug.Log("Player Loses");
        }
       
        //Draw or Neutral Condition
        if (holCurrentNumber == holNewNumber)
        {
            Debug.Log("Neutral");
        }

        

    }
    
   


}

  



