using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //MaxHealth of the Player. Default starting number is 20
    public int MaxHealth = 20;
    public int CurrentHealth;

    //Reference to the players healthbar
    public Healtbar Healthbar;

    //Reference to GameManagerScript
    public GameManager gameManagerScript;

    public Player playerScript;


    //Bool to see if the enemy has yet chosen their move (Used for move validation)
    public bool enemyChosenMove = false;


    //Random int variable
    public int enemyChoice;



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
        //Makes sure that the Enemy hasn't yet chosen anything, otherwise Functions will run once per frame instead of once per turn
        if (!enemyChosenMove && gameManagerScript.enemyTurn == true)
        {
            //Variable used to randomly select whether the Enemy Attacks, Blocks etc....
            enemyChoice = Random.Range(0, 1);

            if (enemyChoice == 0)
            {
                Attack();

            }
            else if (enemyChoice == 1)
            {
                Block();
            }
        }
        // Used for testing remove later so it will cause less lag :) xx
        //It should only be called when we are hit to update it
        Healthbar.sethealth(CurrentHealth);
        Healthbar.UpdateText(CurrentHealth);
    }

    public void Attack()
    {

        enemyChosenMove = true;
        // Attack Code Goes Here

        Debug.Log("Enemy Chooses Attack");

        Debug.Log("Enemy Threatens you with the wrath of doom!...");

        //Starts the Coroutine that allows the Enemies Melee Attack Animation to play out
        StartCoroutine(EnemyMeleeAttackAction());

    }

    public void Block()
    {

        enemyChosenMove = true;

        //Block Code Goes Here

        Debug.Log("Enemy Chooses Block");


    }

    IEnumerator EnemyMeleeAttackAction()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        Debug.Log("Enemy Finished Attacking");

        //Swaps turns after the Attack is done by the player
        gameManagerScript.playerTurn = true;
        gameManagerScript.enemyTurn = false;


        //Changes bool to allow Player to choose a move on their turn
        playerScript.playerChosenMove = false;

    }
}
