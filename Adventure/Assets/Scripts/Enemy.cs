using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    //MaxHealth of the Player. Default starting number is 20
    public int MaxHealth = 0;
    public int CurrentHealth;
    public int JumpPower;
    public int MovementSpeed;
    //Reference to the players healthbar
    public Healtbar Healthbar;

    //Reference to GameManagerScript
    public GameManager gameManagerScript;
    //On Death Show the reward script
    public GameObject RewardText;
    //Enemy gold Drop
    public Text Rewardgold;
    private int Gold;
    //Enemy Xp
    public Text RewardXp;
    private int Xp;

    //Refernce to the Player
    public Player playerScript;

    //Gets Reference to the animator
    public Animator Animator;
    //Bool to see if the enemy has yet chosen their move (Used for move validation)
    public bool enemyChosenMove = false;
    public ParticleSystem Blood;

    //Random int variable
    public int enemyChoice;

    bool Alive = true;

    //Reference to text fade script
    public textFade damagePopupTextScript;
    //Player damage UI that appears on Enemy
    public TMP_Text playerDamageUI;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = Random.Range(6, 12);
        CurrentHealth = MaxHealth;
        Healthbar.setmaxhealth(MaxHealth);
        Healthbar.UpdateText(CurrentHealth);
        JumpPower = 5;
        MovementSpeed = 3;
        Blood.Stop();
        Gold = Random.Range(20, 40);
        Xp = Random.Range(50, 100);
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

        Animator.Play("AttackingGoblins");
        //Debug.Log("Enemy Threatens you with the wrath of doom!...");
       // Debug.Log("Enemy Chooses Attack");
        //Starts the Coroutine that allows the Enemies Melee Attack Animation to play out
        StartCoroutine(EnemyMeleeAttackAction());
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1);
        Debug.DrawRay(transform.position, Vector3.left, Color.green);
        int enemyDamageDone = Random.Range(4, 6);
        if (Hit && playerScript.blockActive == false)
        {
            playerScript.CurrentHealth -= enemyDamageDone;
            damagePopupTextScript.fadingIn = true;
            damagePopupTextScript.damageDone.text = enemyDamageDone.ToString();
            Debug.Log("Hitplayer");
            playerScript.Hurt();
            StartCoroutine(AnimtionRestart());
        }

        else
        {
            Debug.Log("Blocked");
            StartCoroutine(AnimtionRestart());
            playerScript.blockActive = false;
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
            playerScript.blockActive = false;
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
            playerScript.blockActive = false;
            //Jump Code Goes Here
            Debug.Log("Player Chooses Jump");

            GetComponent<Rigidbody2D>().velocity = Vector2.up * JumpPower + Vector2.left;
            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(EnemyMeleeAttackAction());
        }
    }

    IEnumerator EnemyMeleeAttackAction()
    {
        //If the enemy is alive
        if (Alive == true)
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
        else
        {
            death();
        }

    }

    public void Hurt()
    {
        death();
        Animator.Play("Hurt");
       
        Blood.Play();

    }
    //Check if the health is lower then 0 If true the enemy is dead
    private void death()
    {
        if (CurrentHealth <= 0)
        {
            Alive = false;
            Blood.Play();
            Animator.Play("GoblinDead");
            Delay();
            Debug.Log("Dead");
            RewardText.SetActive(true);
            Rewardgold.text = (Gold.ToString());
            RewardXp.text = (Xp.ToString());
            PlayerStats.XP += Xp;
            PlayerStats.Gold += Gold;
          
        }
        else
        {
            StartCoroutine(AnimtionRestart());
        }
    }
    //Restart the animation
    IEnumerator AnimtionRestart()
    {
        if (Alive == true)
        {
            //yield on a new YieldInstruction that waits for 1 seconds.
            yield return new WaitForSeconds(1);
            new WaitForSeconds(1);

            Animator.Play("Idle");
            Blood.Stop();
        }

    }
    IEnumerator Delay()
    {
        if (Alive == false)
        {
            yield return new WaitForSeconds(2);
            new WaitForSeconds(2);
            // not used although I want to use it for the reward screen :( Too buggy dane/josh have a crack on this :eyes:
        }
    }
}