using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //MaxHealth of the Player. Default starting number is 20
    public int MaxHealth = 20;
    public int CurrentHealth;
    public int JumpPower;
    public int MovementSpeed;
    //Reference to the players healthbar
    public Healtbar Healthbar;

    //Reference to GameManagerScript
    public GameManager gameManagerScript;

    public Player playerScript;

    //Gets Reference to the animator
    public Animator Animator;
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
        JumpPower = 5;
        MovementSpeed = 3;
}

    // Update is called once per frame
    void Update()
    {
        //Makes sure that the Enemy hasn't yet chosen anything, otherwise Functions will run once per frame instead of once per turn
        if (!enemyChosenMove && gameManagerScript.enemyTurn == true)
        {
            //Variable used to randomly select whether the Enemy Attacks, Blocks etc....
            enemyChoice = Random.Range(0, 3);

            if (enemyChoice == 0)
            {
                Attack();

            }
            else if (enemyChoice == 1)
            {
                Block();
            }
            if (enemyChoice == 2)
            {
                Move();

            }
            else if (enemyChoice == 3)
            {
                Jump();
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
       

        Debug.Log("Enemy Threatens you with the wrath of doom!...");
        Debug.Log("Enemy Chooses Attack");
        //Starts the Coroutine that allows the Enemies Melee Attack Animation to play out
        StartCoroutine(EnemyMeleeAttackAction());
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1);
        Debug.DrawRay(transform.position, Vector3.left, Color.green);
        if (Hit)
        {
            playerScript.CurrentHealth -= Random.Range(1, 1);
            Debug.Log("Hitplayer");
        }
       
        else
        {
            Debug.Log("Miss");
        }
    }

    public void Block()
    {

        enemyChosenMove = true;

        //Block Code Goes Here

        Debug.Log("Enemy Chooses Block");

        StartCoroutine(EnemyMeleeAttackAction());
    }
    public void Move()
    {
        //Move Code Goes Here
        if (!enemyChosenMove)
        {
            //Stops the player from being able to spam moves in a single turn
            enemyChosenMove = true;

            Debug.Log("Player Chooses Move");
            GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(EnemyMeleeAttackAction());
        }
    }

    public void Jump()
    {
        if (!enemyChosenMove)
        {
            //Stops the player from being able to spam moves in a single turn

            enemyChosenMove = true;
            //Jump Code Goes Here
            Debug.Log("Player Chooses Jump");

            GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpPower + Vector2.left;
            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(EnemyMeleeAttackAction());
        }
    }

    IEnumerator EnemyMeleeAttackAction()
    {
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
        Debug.Log("Enemy Finished Attacking");

        //Swaps turns after the Attack is done by the player
        gameManagerScript.playerTurn = true;
        gameManagerScript.enemyTurn = false;


        //Changes bool to allow Player to choose a move on their turn
        playerScript.playerChosenMove = false;

    }

    public void Hurt()
    {
        Animator.Play("Hurt");
        Animator.Play("Idle");
    }
}
