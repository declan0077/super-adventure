using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //MaxHealth of the Player. Default starting number is 20
    public int MaxHealth = 20;
    public int CurrentHealth;

    //Reference to the players healthbar
    public Healtbar Healthbar;

    //Reference to GameManagerScript
    public GameManager gameManagerScript;


    //Reference to EnemyScript
    public Enemy enemyScript;


    //Checks whether the player has selected their move yet or not
    public bool playerChosenMove = false;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        Healthbar.setmaxhealth(MaxHealth);
        Healthbar.UpdateText(CurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Used for testing remove later so it will cause less lag :) xx
        //It should only be called when we are hit to update it
        Healthbar.sethealth(CurrentHealth);
        Healthbar.UpdateText(CurrentHealth);
    }

    public void Attack()
    {
        if (!playerChosenMove)
        {
            //Stops the player from being able to spam moves in a single turn

            playerChosenMove = true;

            // Attack Code Goes Here

            Debug.Log("Player Chooses Attack");

            Debug.Log("Attacking...");

            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(AttackAction());
        }
        
        
    }

    public void Block()
    {

        if (!playerChosenMove)
        {

            //Stops the player from being able to spam moves in a single turn
            playerChosenMove = true;

            //Block Code Goes Here

            Debug.Log("Player Chooses Block");


            //Swaps turns after the Block is done by the player
            gameManagerScript.playerTurn = false;
            gameManagerScript.enemyTurn = true;

            //Changes bool so that the Enemy is able to choose a move for their turn
            enemyScript.enemyChosenMove = false;
        }



        
    }

    void Move()
    {
        //Move Code Goes Here

        Debug.Log("Player Chooses Move");
    }

    void Jump()
    {
        //Jump Code Goes Here
        Debug.Log("Player Chooses Jump");
    }


    IEnumerator AttackAction()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        Debug.Log("Finished Attacking!");

        //Swaps turns after the Attack is done by the player
        gameManagerScript.playerTurn = false;
        gameManagerScript.enemyTurn = true;

        //Changes bool so that the Enemy is able to choose a move for their turn
        enemyScript.enemyChosenMove = false;
    }
}
