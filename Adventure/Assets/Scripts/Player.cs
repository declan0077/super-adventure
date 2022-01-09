using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //MaxHealth of the Player. Default starting number is 20
    public int MaxHealth = 20;
    public int CurrentHealth;
    public int JumpPower;
    public int Movementspeed;
    //Max damage the player can deal
    public int MaxDamage;
    //Min damage the palyer can deal
    public int MinimumDamage;

    //Reference to the players healthbar
    public Healtbar Healthbar;

    //Gets Reference to the animator
    public Animator Animator;
    //Reference to GameManagerScript
    public GameManager gameManagerScript;

    public Transform look;
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
        MaxDamage = 4;
        MinimumDamage = 1;
        JumpPower = 5;
        Movementspeed = 3;
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 10);
        Debug.DrawLine(transform.position, Hit.point, Color.blue);
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
            RaycastHit2D Hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 10);
            if (Hit)
            {
                enemyScript.CurrentHealth -= Random.Range(MinimumDamage, MaxDamage);
                Debug.Log("HitYaFucker");
                enemyScript.Hurt();
            }
            Debug.DrawLine(transform.position, Hit.point, Color.blue);
        }
        Animator.Play("Attack");

    }

    public void Block()
    {

        if (!playerChosenMove)
        {

            //Stops the player from being able to spam moves in a single turn
            playerChosenMove = true;

            //Block Code Goes Here

            Debug.Log("Player Chooses Block");
            Animator.Play("Block");

            //Swaps turns after the Block is done by the player
            gameManagerScript.playerTurn = false;
            gameManagerScript.enemyTurn = true;

            //Changes bool so that the Enemy is able to choose a move for their turn
            enemyScript.enemyChosenMove = false;
        }



        
    }

    public void Move()
    {
        //Move Code Goes Here
        if (!playerChosenMove)
        {
            //Stops the player from being able to spam moves in a single turn
            playerChosenMove = true;

            Debug.Log("Player Chooses Move");
            GetComponent<Rigidbody2D>().velocity = Vector2.right * Movementspeed;
            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(AttackAction());
            Animator.Play("Walk");
        }
    }

    public void Jump()
    {
        if (!playerChosenMove)
        {
            //Stops the player from being able to spam moves in a single turn

            playerChosenMove = true;
            //Jump Code Goes Here
            Debug.Log("Player Chooses Jump");

            GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpPower + Vector2.right;
            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(AttackAction());
            Animator.Play("Jump");
        }
    }


    IEnumerator AttackAction()
    {
        Animation();
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
        Debug.Log("Finished Attacking!");
        
        //Swaps turns after the Attack is done by the player
        gameManagerScript.playerTurn = false;
        gameManagerScript.enemyTurn = true;

        //Changes bool so that the Enemy is able to choose a move for their turn
        enemyScript.enemyChosenMove = false;
     
    }

    public void Animation()
    {
        Animator.Play("Idle");
    }


}
