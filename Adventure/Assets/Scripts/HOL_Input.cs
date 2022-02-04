using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOL_Input : MonoBehaviour
{

    public Gamba gameplayController;
    public string playerChoice;
    // Start is called before the first frame update
    void Awake()
    {
        gameplayController = GetComponent<Gamba>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetChoice()
    {
        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        print("Player Selected" + choiceName);
        holChoices selectedChoice = holChoices.NONE;

        switch (choiceName)
        {
            case "Higher":
                selectedChoice = holChoices.HIGHER;
                break;
            case "Lower":
                selectedChoice = holChoices.LOWER;
                break;
               
        }

        gameplayController.SetHOLChoices(selectedChoice);
    }
}
