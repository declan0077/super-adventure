using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPS_Input : MonoBehaviour
{
    public Gamba gameplayController;
    public string playerChoice;

    void Awake()
    {
        gameplayController = GetComponent<Gamba>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetChoice()
    {
        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        print("Player Selected" + choiceName);
        rpsChoices selectedChoice = rpsChoices.NONE;

        switch (choiceName)
        {
            case "Rock":
                selectedChoice = rpsChoices.ROCK;
                break;
            case "Paper":
                selectedChoice = rpsChoices.PAPER;
                break;
            case "Scissors":
                selectedChoice = rpsChoices.SCISSORS;
                break;
        }

        gameplayController.SetRPSChoices(selectedChoice);
    }
}
