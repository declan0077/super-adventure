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
    public AudioSource[] goblinSounds;
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
    //Refernce to the type of Enemy
    public int MonsterType;

    //Gets Reference to the animator
    public Animator Animator;
    //Bool to see if the enemy has yet chosen their move (Used for move validation)
    public bool enemyChosenMove = false;
    public ParticleSystem Blood;
    //Gets the center of the players body used for raycasting
    public GameObject Body;
    //Random int variable
    public int enemyChoice;
    public ArmourBar ArmourBar;
    //Armour ammount
    public int MaxArmour;
    public int CurrentArmour;
    bool Alive = true;

    //Block Defense Value
    public int blockDefense = 0;
    public GameObject blockDefenseIcon;
    public Text blockDefenseValue;

    //Reference to text fade script
    public textFade damagePopupTextScript;
    //Player damage UI that appears on Enemy
    public TMP_Text playerDamageUI;
    private bool PlayerInrange;

    //Reference to block skillcheck
    public GameObject blockSkillCheck;
    public SkillcheckSpin blockSkillScript;

    public int randomSound;

    public AudioSource playerHurt;
   
    // Start is called before the first frame update
    void Start()
    {
        switch (MonsterType)
        {
            case 1:
                MaxHealth = Random.Range(6, 12);
                Healthbar.Setmaxhealth(MaxHealth);
                Healthbar.UpdateText(CurrentHealth);
                CurrentHealth = MaxHealth;
                JumpPower = 5;
                MovementSpeed = 4;
                Blood.Stop();
                Gold = Random.Range(20, 40);
                Xp = Random.Range(50, 100);
                ArmourBar.SetmaxArmour(MaxArmour);
                ArmourBar.UpdateText(CurrentArmour);
                CurrentArmour = MaxArmour;

                break;
            case 2:
                MaxHealth = Random.Range(12, 24);
                Healthbar.Setmaxhealth(MaxHealth);
                Healthbar.UpdateText(CurrentHealth);
                CurrentHealth = MaxHealth;
                JumpPower = 5;
                MovementSpeed = 3;
                Blood.Stop();
                Gold = Random.Range(20, 40);
                Xp = Random.Range(50, 100);
                MaxArmour = 5;
                ArmourBar.SetmaxArmour(MaxArmour);
                ArmourBar.UpdateText(CurrentArmour);
                CurrentArmour = MaxArmour;
                break;
            case 3:
                MaxHealth = Random.Range(24, 48);
                Healthbar.Setmaxhealth(MaxHealth);
                Healthbar.UpdateText(CurrentHealth);
                CurrentHealth = MaxHealth;
                JumpPower = 5;
                MovementSpeed = 3;
                Blood.Stop();
                Gold = Random.Range(20, 40);
                Xp = Random.Range(50, 100);
                MaxArmour = 10;
                ArmourBar.SetmaxArmour(MaxArmour);
                ArmourBar.UpdateText(CurrentArmour);
                CurrentArmour = MaxArmour;
                break;

        }
            

    }

    // Update is called once per frame
    void Update()
    {
        blockDefenseValue.text = blockDefense.ToString();


        //Disables the block defense UI if not needed
        if (blockDefense <= 0)
        {
            blockDefenseIcon.SetActive(false);
            //Setting it back to 0 allows you to reactivate shield without having to work you way up from negative number
            blockDefense = 0;
        }

        if (blockDefense >= 1)
        {
            blockDefenseIcon.SetActive(true);
        }

        ArmourBar.SetArmour(CurrentArmour);
        ArmourBar.UpdateText(CurrentArmour);
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
        Healthbar.Sethealth(CurrentHealth);
        Healthbar.UpdateText(CurrentHealth);
        ArmourBar.UpdateText(CurrentArmour);
        RaycastHit2D Inrange = Physics2D.Raycast(Body.transform.position, -Body.transform.right, 1.5f);
        if(Inrange.collider != null && Inrange.collider.tag == "Player")
        {
            PlayerInrange = true;
        }
        else if (Inrange.collider == null)
        {
            PlayerInrange = false;
        }
    }

    public void Attack()
    {
        enemyChosenMove = true;
        // Attack Code Goes Here
        StartCoroutine(EnemyMeleeAttackAction());

        //Debug.Log("Enemy Threatens you with the wrath of doom!...");
        // Debug.Log("Enemy Chooses Attack");
        //Starts the Coroutine that allows the Enemies Melee Attack Animation to play out

        RaycastHit2D Hit = Physics2D.Raycast(Body.transform.position, -Body.transform.right, 1.5f);

        //Damage conditions for Enemy to damage player
        switch (MonsterType)
        {
            case 1:
               
                if (Hit.collider != null && Hit.collider.tag == "Player")
                {
                    int enemyDamageDone = Random.Range(4, 6);
                    int overDamage = 0;
                    if (playerScript.CurrentArmour <= 0 && playerScript.blockDefense == 0)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                        playerHurt.Play();
                    }
                    //Checking to see if the Player has any Block Shield value remaining. Prioritizes shield over direct health.
                    else if (playerScript.blockDefense > 0 && playerScript.blockDefense > enemyDamageDone)
                    {
                        playerScript.blockDefense -= enemyDamageDone;
                    }
                    //Allows the Enemy to deal damage to the player with the same attack they use to break through the defense shield (In case of over damage)
                    else if(playerScript.blockDefense > 0 && playerScript.blockDefense < enemyDamageDone)
                    {
                        playerScript.blockDefense -= enemyDamageDone;
                        overDamage = enemyDamageDone - playerScript.blockDefense;
                        playerScript.CurrentHealth -= overDamage;
                        playerHurt.Play();

                    }
                    else if (playerScript.CurrentArmour >= 0)
                    {
                        playerScript.CurrentArmour -= enemyDamageDone;
                    }
                    damagePopupTextScript.fadingIn = true;
                    damagePopupTextScript.damageDone.text = enemyDamageDone.ToString();
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("GoblinAttack");
                    StartCoroutine(EnemyMeleeAttackAction());
                }

          
                //Checks if Player is close enough for Enemy to attack
                else if (Hit.collider == null)
                {

                    Getcloser();
                    playerScript.blockActive = false;
                    StartCoroutine(AnimtionRestart());
                }
                break;
            case 2:
                
                if (Hit && playerScript.blockActive == false && Hit.collider != null && Hit.collider.tag == "Player")
                {
                    int enemyDamageDone = Random.Range(4, 12);
                    if (playerScript.CurrentArmour <= 0)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                    }
                    else if (playerScript.CurrentArmour >= 0)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                    }

                    damagePopupTextScript.fadingIn = true;
                    damagePopupTextScript.damageDone.text = enemyDamageDone.ToString();
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("SkeletonAttack");
                    StartCoroutine(EnemyMeleeAttackAction());
                }

                else if (Hit.collider == null)
                {

                    Getcloser();
                    playerScript.blockActive = false;
                    StartCoroutine(AnimtionRestart());
                }
                break;
            case 3:
                
                if (Hit && playerScript.blockActive == false && Hit.collider != null && Hit.collider.tag == "Player")
                {
                    int enemyDamageDone = Random.Range(4, 24);
                    if (playerScript.CurrentArmour <= 0)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                    }
                    else if (playerScript.CurrentArmour >= 0)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                    }
                    
                    damagePopupTextScript.fadingIn = true;
                    damagePopupTextScript.damageDone.text = enemyDamageDone.ToString();
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("OrcAttack");
                    StartCoroutine(EnemyMeleeAttackAction());
                }

                else if (Hit.collider == null)
                {

                    Getcloser();
                    playerScript.blockActive = false;
                    StartCoroutine(AnimtionRestart());
                }
                break;
        }
       
    }

    public void Block()
    {
        switch (MonsterType)
        {
            case 1:
                if (PlayerInrange == true)
                {
                    enemyChosenMove = true;
                    Animator.Play("GoblinBlock");
                    //Block Code Goes Here

                    Debug.Log("Enemy Chooses Block");
                    blockDefense += 1;

                    StartCoroutine(EnemyMeleeAttackAction());
                    StartCoroutine(AnimtionRestart());
                }
                else
                {
                    Getcloser();
                }
                break;
            case 2:
                if (PlayerInrange == true)
                {
                    enemyChosenMove = true;
                    Animator.Play("SkeletonBlock");
                    //Block Code Goes Here

                    Debug.Log("Enemy Chooses Block");

                    StartCoroutine(EnemyMeleeAttackAction());
                    StartCoroutine(AnimtionRestart());
                }
                else
                {
                    Getcloser();
                }
                break;
            case 3:
                if (PlayerInrange == true)
                {
                    enemyChosenMove = true;
                    Animator.Play("OrcBlock");
                    //Block Code Goes Here

                    Debug.Log("Enemy Chooses Block");

                    StartCoroutine(EnemyMeleeAttackAction());
                    StartCoroutine(AnimtionRestart());
                }
                else
                {
                    Getcloser();
                }
                break;
        }
       
    }
    public void Move()
    {
        switch (MonsterType)
        {
            case 1:
                //Move Code Goes Here
                if (!enemyChosenMove)
                {
                    if (PlayerInrange == true)
                    {

                        Attack();
                    }
                    else
                    {
                        //Stops the player from being able to spam moves in a single turn
                        enemyChosenMove = true;
                        playerScript.blockActive = false;
                        Debug.Log("Enemy Chooses Move");
                        Animator.Play("GoblinWalk");
                        GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
                        //Starts the Coroutine that allows the Attack Animation to play out
                        StartCoroutine(EnemyMeleeAttackAction());
                        StartCoroutine(AnimtionRestart());
                    }

                }
                break;
            case 2:
                //Move Code Goes Here
                if (!enemyChosenMove)
                {
                    if (PlayerInrange == true)
                    {
                        Attack();
                    }
                    else
                    {
                        //Stops the player from being able to spam moves in a single turn
                        enemyChosenMove = true;
                        playerScript.blockActive = false;
                        Debug.Log("Enemy Chooses Move");
                        Animator.Play("SkeletonWalk");
                        GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
                        //Starts the Coroutine that allows the Attack Animation to play out
                        StartCoroutine(EnemyMeleeAttackAction());
                        StartCoroutine(AnimtionRestart());
                    }

                }
                break;
            case 3:
                //Move Code Goes Here
                if (!enemyChosenMove)
                {
                    if (PlayerInrange == true)
                    {
                        Attack();
                    }
                    else
                    {
                        //Stops the player from being able to spam moves in a single turn
                        enemyChosenMove = true;
                        playerScript.blockActive = false;
                        Debug.Log("Enemy Chooses Move");
                        Animator.Play("OrcWalk");
                        GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
                        //Starts the Coroutine that allows the Attack Animation to play out
                        StartCoroutine(EnemyMeleeAttackAction());
                        StartCoroutine(AnimtionRestart());
                    }

                }
                break;
        }
        
    }
    //Same as move just used in the attack command
    public void Getcloser()
    {
        switch (MonsterType)
        {
            case 1:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
                Animator.Play("GoblinWalk");
                StartCoroutine(AnimtionRestart());
                break;
            case 2:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
                Animator.Play("SkeletonWalk");
                StartCoroutine(AnimtionRestart());
                break;
            case 3:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
                Animator.Play("OrcWalk");
                StartCoroutine(AnimtionRestart());
                break;
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
            Debug.Log("Enemy Chooses Jump");

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
            //yield on a new YieldInstruction that waits for 1 seconds.
            yield return new WaitForSeconds(1);
            Debug.Log("EnemyTurnOver");

            //Swaps turns after the Attack is done by the player
            gameManagerScript.playerTurn = true;
            gameManagerScript.enemyTurn = false;


            //Changes bool to allow Player to choose a move on their turn
            playerScript.playerChosenMove = false;
        }
        else
        {
            Death();
        }

    }

    public void Hurt()
    {

       
        switch (MonsterType)
        {
            case 1:
                AudioSource GoblinSounds = goblinSounds[Random.Range(0, 2)];
                GoblinSounds.Play();
                Death();
                Animator.Play("GoblinHurt");  
                Blood.Play();
                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.material.color = Color.red;
                }
                StartCoroutine(HurtFlash());
               
                break;
            case 2:
                Death();
                Animator.Play("SkeletonHurt");
                Blood.Play();
                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.material.color = Color.red;
                }
                StartCoroutine(HurtFlash());
                break;
            case 3:
                Death();
                Animator.Play("OrcHurt");
                Blood.Play();
                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                    sr.material.color = Color.red;
                }
                StartCoroutine(HurtFlash());
                break;
        }
      

    }
    IEnumerator HurtFlash()
    {

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(0.5f);
        new WaitForSeconds(0.5f);
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = Color.white;
        }

    }
    //Check if the health is lower then 0 If true the enemy is dead
    private void Death()
    {
        switch (MonsterType)
        {
            case 1:
                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                    Healthbar.UpdateText(CurrentHealth);
                    Alive = false;
                    Blood.Play();
                    Animator.Play("GoblinDead");
                    Delay();
                    Debug.Log("Dead");
                    RewardText.SetActive(true);
                    RewardText.GetComponent<Animator>().Play("RewardSlideIn");
                    Rewardgold.text = (Gold.ToString());
                    RewardXp.text = (Xp.ToString());
                    PlayerStats.XP += Xp;
                    PlayerStats.Gold += Gold;
                    Destroy(this);

                }
                else
                {
                    StartCoroutine(AnimtionRestart());
                }
                break;
            case 2:
                if (CurrentHealth <= 0)
                {
                    Alive = false;
                    Blood.Play();
                    Animator.Play("Skeletondead");
                    Delay();
                    Debug.Log("Dead");
                    RewardText.SetActive(true);
                    RewardText.GetComponent<Animator>().Play("RewardSlideIn");
                    Rewardgold.text = (Gold.ToString());
                    RewardXp.text = (Xp.ToString());
                    PlayerStats.XP += Xp;
                    PlayerStats.Gold += Gold;
                    Destroy(this);

                }
                else
                {
                    StartCoroutine(AnimtionRestart());
                }
                break;
            case 3:
                if (CurrentHealth <= 0)
                {
                    Alive = false;
                    Blood.Play();
                    Animator.Play("OrcDead");
                    Delay();
                    Debug.Log("Dead");
                    RewardText.SetActive(true);
                    RewardText.GetComponent<Animator>().Play("RewardSlideIn");
                    Rewardgold.text = (Gold.ToString());
                    RewardXp.text = (Xp.ToString());
                    PlayerStats.XP += Xp;
                    PlayerStats.Gold += Gold;
                    Destroy(this);

                }
                else
                {
                    StartCoroutine(AnimtionRestart());
                }
                break;
        }

    }
    //Restart the animation
    IEnumerator AnimtionRestart()
    {
        switch (MonsterType)
        {
            case 1:
                if (Alive == true)
                {
                    //yield on a new YieldInstruction that waits for 1 seconds.
                    yield return new WaitForSeconds(1);
                    new WaitForSeconds(1);

                    Animator.Play("GoblinIdle");
                    Blood.Stop();
                }
                break;
            case 2:
                if (Alive == true)
                {
                    //yield on a new YieldInstruction that waits for 1 seconds.
                    yield return new WaitForSeconds(1);
                    new WaitForSeconds(1);

                    Animator.Play("SkeletonIdle");
                    Blood.Stop();
                }
                break;
            case 3:
                if (Alive == true)
                {
                    //yield on a new YieldInstruction that waits for 1 seconds.
                    yield return new WaitForSeconds(1);
                    new WaitForSeconds(1);

                    Animator.Play("OrcIdle");
                    Blood.Stop();
                }
                break;
        }

    }

    IEnumerator Delay()
    {
        if (Alive == false)
        {
            yield return new WaitForSeconds(1);
            new WaitForSeconds(2);
            // not used although I want to use it for the reward screen :( Too buggy dane/josh have a crack on this :eyes:
        }
    }
    public void Blockdamage()
    {
 
        switch (MonsterType)
        {
            case 1:
                    int GoblinDamage = Random.Range(4, 6);
                    playerScript.CurrentHealth -= GoblinDamage;
                    damagePopupTextScript.fadingIn = true;
                    damagePopupTextScript.damageDone.text = GoblinDamage.ToString();
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("GoblinAttack");
                    StartCoroutine(EnemyMeleeAttackAction());

                break;
            case 2:

                    int SkeletonDamage = Random.Range(4, 12);
                    playerScript.CurrentHealth -= SkeletonDamage;
                    damagePopupTextScript.fadingIn = true;
                    damagePopupTextScript.damageDone.text = SkeletonDamage.ToString();
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("SkeletonAttack");
                    StartCoroutine(EnemyMeleeAttackAction());
      
                break;
            case 3:

            
                    int OrcDamage = Random.Range(4, 24);
                    playerScript.CurrentHealth -= OrcDamage;
                    damagePopupTextScript.fadingIn = true;
                    damagePopupTextScript.damageDone.text = OrcDamage.ToString();
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("OrcAttack");
                    StartCoroutine(EnemyMeleeAttackAction());
           
                break;
        }

    }
}