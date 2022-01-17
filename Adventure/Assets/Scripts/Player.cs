using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    //Reference to The Players Body 
    public GameObject Body;
    //Reference to The Players Shield 
    public GameObject Shield;



    //Reference to EnemyScript
    public Enemy enemyScript;
    public ParticleSystem Blood;

    //Checks whether the player has selected their move yet or not
    public bool playerChosenMove = false;


    //Block Checker
    public bool blockActive = false;

    //AttackChecker
    public bool attacking = true;



    //Reference to text fade script
    public textFade damagePopupTextScript;
    //Player damage UI that appears on Enemy
    public TMP_Text playerDamageUI;



    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = MaxHealth + PlayerStats.Constitution;
        CurrentHealth = MaxHealth;
        Healthbar.setmaxhealth(MaxHealth);
        Healthbar.UpdateText(CurrentHealth);
        Blood.Stop();
        if(PlayerStats.ShieldLevel >= 1)
        {
            Shield.gameObject.SetActive(true);
        }

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

        Debug.DrawLine(Body.transform.position, Body.transform.position + Body.transform.right, Color.blue);

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

            int playerDamageDone = Random.Range(MinimumDamage, MaxDamage);
            attacking = true;
            RaycastHit2D Hit = Physics2D.Raycast(Body.transform.position, Body.transform.position + Body.transform.right, 10000);
            Debug.Log(Hit.collider.name);
            //Hit.collider.gameObject.CompareTag("Enemy"))
            if (Hit)
            {
                Debug.Log(Hit.collider.name);
                enemyScript.CurrentHealth -= playerDamageDone + PlayerStats.Strength;
                damagePopupTextScript.fadingIn = true;
                int OverallDamage = PlayerStats.Strength + playerDamageDone;
                damagePopupTextScript.damageDone.text = OverallDamage.ToString();
                Debug.Log("HitYa");
                enemyScript.Hurt();
            }

            Animator.Play("Attack");
        }

        StartCoroutine(AnimtionRestart());
    }

    public void Block()
    {

        if (!playerChosenMove)
        {
            blockActive = true;
            //Stops the player from being able to spam moves in a single turn
            playerChosenMove = true;

            //Block Code Goes Here

            Debug.Log("Player Chooses Block");
            Animator.Play("Block");
            StartCoroutine(AnimtionRestart());
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
            int OverallSpeed = Movementspeed + PlayerStats.Agility;
            GetComponent<Rigidbody2D>().velocity = Vector2.right * OverallSpeed;
            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(AttackAction());

            Animator.Play("Walk");
            StartCoroutine(AnimtionRestart());
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
            int OverallJumpPower = JumpPower + PlayerStats.Agility;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * OverallJumpPower + Vector2.right;
            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(AttackAction());
            Animator.Play("Jump");
            StartCoroutine(AnimtionRestart());


        }
    }

    public void Hurt()
    {

        Animator.Play("PlayerHurt");
        Blood.Play();
        StartCoroutine(AnimtionRestart());

    }

    IEnumerator AttackAction()
    {

        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
        Debug.Log("Finished Attacking!");

        //Swaps turns after the Attack is done by the player
        gameManagerScript.playerTurn = false;
        gameManagerScript.enemyTurn = true;

        //Changes bool so that the Enemy is able to choose a move for their turn
        enemyScript.enemyChosenMove = false;

    }
    IEnumerator AnimtionRestart()
    {

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        new WaitForSeconds(1);

        Animator.Play("PlayerCharacter");
        Blood.Stop();
    }


}
