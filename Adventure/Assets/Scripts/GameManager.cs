using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool playerTurn = true;
    [SerializeField] private bool enemyTurn = false;


    //Text Displayed if it's the Players turn.
    [SerializeField] private Text p_turnText;

    //Text Displayed if it's the Enemys turn.
    [SerializeField] private Text e_turnText;


    [SerializeField] private GameObject playerChoiceUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTurn && !enemyTurn)
        {
            p_turnText.enabled = true;
            playerChoiceUI.SetActive(true);
        }
        else if (enemyTurn && !playerTurn)
        {
            e_turnText.enabled = true;
            playerChoiceUI.SetActive(false);
        }
        else
        {
            p_turnText.enabled = false;
            e_turnText.enabled = false;
        }
    }
}
