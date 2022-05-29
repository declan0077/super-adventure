//script created by Dane Donaldson and Declan Cullen

//script Formatted by Dane Donaldson on 27-05-22
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    //Reference to ScriptableObject Holder
    public EnemyStatHolder statHolder;

    //Stat Holder
    public int maxHealth = 0;
    public int currentHealth;
    public int movementSpeed;

    //UI Holders
    public Text rewardGold;
    public Text rewardExperience;
    public Text blockDefenseValue;
    public TMP_Text playerDamageUI;

    //Script References
    public GameManager gameManagerScript;
    public MeleeWeaponTrail weaponEffectScript;
    public Healtbar healthBar;
    public Player playerScript;
    public textFade damagePopupTextScript;
    public SkillcheckSpin blockSkillScript;
    public ArmourBar ArmourBar;

    //Audio
    public AudioSource[] malePlayerHurt;
    public AudioSource[] femalePlayerHurt;
    public AudioSource[] enemySounds;

    //Bool Checks

    //Bool to see if the enemy has yet chosen their move (Used for move validation)
    public bool enemyChosenMove = false;
    public bool Alive = true;
    private bool playerInrange;
    public bool isPushed = false;

    public Animator Animator;

    //Integers
    private int Gold;
    private int Xp;
    public int enemyChoice;
    public int MaxArmour;
    public int CurrentArmour;
    public int blockDefense = 0;
    public int MonsterType;
    public int enemyDamageDone;
    public int overDamage = 0;
    public int randomSound;

    //GameObjects
    public GameObject RewardText;
    public GameObject blockDefenseIcon;
    public GameObject Body;
    public GameObject blockSkillCheck;
    public GameObject whosTurn;

     public ParticleSystem Blood;



    // Start is called before the first frame update
    void Start()
    {
        //Primary Stats
        enemyDamageDone = statHolder.damage;
        currentHealth = statHolder.health;
        maxHealth = statHolder.health;

        //Secondary Stats
        movementSpeed = statHolder.moveSpeed;
        Gold = statHolder.goldGiven;
        Xp = statHolder.xpGiven;
        CurrentArmour = MaxArmour;
        MaxArmour = statHolder.armor;

        //UI
        healthBar.Setmaxhealth(maxHealth);
        healthBar.UpdateText(currentHealth);
        ArmourBar.SetmaxArmour(MaxArmour);
        ArmourBar.UpdateText(CurrentArmour);

        //Bug Preventions
        Blood.Stop();

        //Audio
        enemySounds = statHolder.vocalSounds;
    }

    // Update is called once per frame
    void Update()
    {

        UIUpdates();
        EnemyTurnChoice();

        RaycastHit2D Inrange = Physics2D.Raycast(Body.transform.position, -Body.transform.right, 1.5f);
        if (Inrange.collider != null && Inrange.collider.tag == "Player")
        {
            playerInrange = true;
        }
        else if (Inrange.collider == null)
        {
            playerInrange = false;
        }
    }
    public void Deathaction()
    {
        enemyChosenMove = true;
    }
    public void Attack()
    {
        enemyChosenMove = true;
        StartCoroutine(EnemyMeleeAttackAction());
        RaycastHit2D Hit = Physics2D.Raycast(Body.transform.position, -Body.transform.right, 1.5f);

        int OverallDamage = Random.Range(1, 6);

        if (Hit.collider != null && Hit.collider.tag == "Player")
        {

            //IF PLAYER HAS NO ARMOR AND NO BLOCK SHIELD + PLAYER HAS RED AMULET
            if (playerScript.CurrentArmour <= 0 && playerScript.blockDefense == 0 && playerScript.redSpellPurchased == true)
            {
                playerScript.CurrentHealth -= enemyDamageDone;
                currentHealth -= 1;
                if (PlayerStats.Male)
                {
                    malePlayerHurt[Random.Range(0, malePlayerHurt.Length)].Play();
                }
                else
                {
                    femalePlayerHurt[Random.Range(0, femalePlayerHurt.Length)].Play();
                }
            }

            //IF PLAYER HAS NO ARMOR AND NO BLOCK SHIELD + PLAYER HAS RED AMULET
            else if (playerScript.CurrentArmour <= 0 && playerScript.blockDefense == 0 && playerScript.redSpellPurchased == false)
            {
                playerScript.CurrentHealth -= enemyDamageDone;
                if (PlayerStats.Male)
                {
                    malePlayerHurt[Random.Range(0, malePlayerHurt.Length)].Play();
                }
                else
                {
                    femalePlayerHurt[Random.Range(0, femalePlayerHurt.Length)].Play();
                }
            }
            //IF PLAYER HAS ARMOR + NO BLOCK DEFENSE + HAS RED AMULET
            else if (playerScript.CurrentArmour > 0 && playerScript.blockDefense == 0 && playerScript.redSpellPurchased == true)
            {
                if (OverallDamage > playerScript.CurrentArmour)
                {
                    overDamage = OverallDamage - playerScript.CurrentArmour;
                    playerScript.CurrentHealth -= overDamage;
                    currentHealth -= 1;
                    if (PlayerStats.Male)
                    {
                        malePlayerHurt[Random.Range(0, malePlayerHurt.Length)].Play();
                    }
                    else
                    {
                        femalePlayerHurt[Random.Range(0, femalePlayerHurt.Length)].Play();
                    }
                }
                else if (OverallDamage <= playerScript.CurrentArmour)
                {
                    playerScript.CurrentArmour -= OverallDamage;
                }
            }
            //IF PLAYER HAS ARMOR + NO BLOCK DEFENSE + HAS NO RED AMULET
            else if (playerScript.CurrentArmour > 0 && playerScript.blockDefense == 0 && playerScript.redSpellPurchased == false)
            {
                if (OverallDamage > playerScript.CurrentArmour)
                {
                    overDamage = OverallDamage - playerScript.CurrentArmour;
                    playerScript.CurrentHealth -= overDamage;
                    playerScript.CurrentArmour = 0;
                    if (PlayerStats.Male)
                    {
                        malePlayerHurt[Random.Range(0, malePlayerHurt.Length)].Play();
                    }
                    else
                    {
                        femalePlayerHurt[Random.Range(0, femalePlayerHurt.Length)].Play();
                    }

                }
                else if (OverallDamage <= playerScript.CurrentArmour)
                {
                    playerScript.CurrentArmour -= OverallDamage;
                }
            }
            //IF PLAYER HAS NO ARMOR + HAS BLOCK DEFENSE + RED AMULET
            else if (playerScript.CurrentArmour == 0 && playerScript.blockDefense > 0 && playerScript.redSpellPurchased == true)
            {
                if (OverallDamage > playerScript.blockDefense)
                {
                    overDamage = OverallDamage - playerScript.blockDefense;
                    playerScript.CurrentHealth -= overDamage;
                    playerScript.blockDefense = 0;
                    currentHealth -= 1;
                    if (PlayerStats.Male)
                    {
                        malePlayerHurt[Random.Range(0, malePlayerHurt.Length)].Play();
                    }
                    else
                    {
                        femalePlayerHurt[Random.Range(0, femalePlayerHurt.Length)].Play();
                    }
                }
                else if (OverallDamage <= playerScript.blockDefense)
                {
                    playerScript.blockDefense -= OverallDamage;
                }
            }
            else if (playerScript.CurrentArmour == 0 && playerScript.blockDefense > 0 && playerScript.redSpellPurchased == false)
            {
                if (OverallDamage > playerScript.blockDefense)
                {
                    overDamage = OverallDamage - playerScript.blockDefense;
                    playerScript.CurrentHealth -= overDamage;
                    playerScript.blockDefense = 0;
                    if (PlayerStats.Male)
                    {
                        malePlayerHurt[Random.Range(0, malePlayerHurt.Length)].Play();
                    }
                    else
                    {
                        femalePlayerHurt[Random.Range(0, femalePlayerHurt.Length)].Play();
                    }
                }
                else if (OverallDamage <= playerScript.blockDefense)
                {
                    playerScript.blockDefense -= OverallDamage;
                }
            }

            else if (playerScript.CurrentArmour > 0 && playerScript.blockDefense > 0 && playerScript.redSpellPurchased == true)
            {
                if (OverallDamage > playerScript.blockDefense)
                {
                    overDamage = OverallDamage - playerScript.blockDefense;
                    playerScript.blockDefense = 0;

                    if (overDamage > playerScript.CurrentArmour)
                    {
                        overDamage -= playerScript.CurrentArmour;
                        playerScript.CurrentArmour = 0;
                        playerScript.CurrentHealth -= overDamage;
                        currentHealth -= 1;
                        if (PlayerStats.Male)
                        {
                            malePlayerHurt[Random.Range(0, malePlayerHurt.Length)].Play();
                        }
                        else
                        {
                            femalePlayerHurt[Random.Range(0, femalePlayerHurt.Length)].Play();
                        }
                    }
                    else if (overDamage <= playerScript.CurrentArmour)
                    {
                        playerScript.CurrentArmour -= overDamage;
                    }

                }
                else if (OverallDamage <= playerScript.blockDefense)
                {
                    playerScript.blockDefense -= OverallDamage;
                }
            }
            else if (playerScript.CurrentArmour > 0 && playerScript.blockDefense > 0 && playerScript.redSpellPurchased == false)
            {
                if (OverallDamage > playerScript.blockDefense)
                {
                    overDamage = OverallDamage - playerScript.blockDefense;
                    playerScript.blockDefense = 0;

                    if (overDamage > playerScript.CurrentArmour)
                    {
                        overDamage -= playerScript.CurrentArmour;
                        playerScript.CurrentArmour = 0;
                        if (PlayerStats.Male)
                        {
                            malePlayerHurt[Random.Range(0, malePlayerHurt.Length)].Play();
                        }
                        else
                        {
                            femalePlayerHurt[Random.Range(0, femalePlayerHurt.Length)].Play();
                        }
                    }
                    else if (overDamage <= playerScript.CurrentArmour)
                    {
                        playerScript.CurrentArmour -= overDamage;
                    }

                }
                else if (OverallDamage <= playerScript.blockDefense)
                {
                    playerScript.blockDefense -= OverallDamage;
                }
            }
            damagePopupTextScript.fadingIn = true;
            damagePopupTextScript.damageDone.text = OverallDamage.ToString();
            playerScript.Hurt();
            StartCoroutine(AnimtionRestart());
            Animator.Play(statHolder.attackAnimation.ToString());
            weaponEffectScript.Emit = true;
            StartCoroutine(EnemyMeleeAttackAction());
        }


        //Checks if Player is close enough for Enemy to attack
        else if (Hit.collider == null)
        {
            Getcloser();
            playerScript.blockActive = false;
            StartCoroutine(AnimtionRestart());
        }

    }

    public void Block()
    {
        if (playerInrange == true)
        {
            enemyChosenMove = true;
            Animator.Play(statHolder.blockAnimation.ToString());
            blockDefense += 1;
            StartCoroutine(EnemyMeleeAttackAction());
            StartCoroutine(AnimtionRestart());
        }
        else
        {
            Getcloser();
        }

    }
    public void Move()
    {
        if (playerInrange == true)
        {
            Attack();
        }
        else
        {
            //Stops the player from being able to spam moves in a single turn
            enemyChosenMove = true;
            playerScript.blockActive = false;
            Animator.Play(statHolder.walkAnimation.ToString());
            GetComponent<Rigidbody2D>().velocity = Vector2.left * movementSpeed;
            //Starts the Coroutine that allows the Attack Animation to play out
            StartCoroutine(EnemyMeleeAttackAction());
            StartCoroutine(AnimtionRestart());
        }
    }

    public void Pushed()
    {
        if (isPushed)
        {
            Debug.Log("Enemy Pushed");
            Animator.Play(statHolder.walkAnimation.ToString());
            //Forces the Enemy back 2 spaces
            GetComponent<Rigidbody2D>().velocity = (Vector2.right * 2) * movementSpeed;
            isPushed = false;

        }
    }
    public void Getcloser()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * movementSpeed;
        Animator.Play(statHolder.walkAnimation.ToString());
        StartCoroutine(AnimtionRestart());
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
            weaponEffectScript.Emit = false;
        }
        else
        {
            Death();
        }

    }

    public void Hurt()
    {
        //Audio that is played when the Enemy is struck/hurt - Commented out while no audio chosen.

        //enemySounds[Random.Range(0, enemySounds.Length)].Play();

        Animator.Play(statHolder.hurtAnimation.ToString());
        Death();
        Blood.Play();
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = Color.red;
        }
        StartCoroutine(HurtFlash());
    }
    IEnumerator HurtFlash()
    {

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1f);
        new WaitForSeconds(1f);
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = Color.white;
        }

    }
    //Check if the health is lower then 0 If true the enemy is dead
    private void Death()
    {
        if (currentHealth <= 0)
        {
            //Prevents the UI from displaying Health text in the minus
            currentHealth = 0;
            //Prevents the Enemy from attacking once more after death
            enemyDamageDone = 0;
            healthBar.UpdateText(currentHealth);
            Alive = false;
            Blood.Play();
            Animator.Play(statHolder.deathAnimation.ToString());
            Delay();
            RewardText.SetActive(true);
            RewardText.GetComponent<Animator>().Play("RewardSlideIn");
            whosTurn.SetActive(false);
            rewardGold.text = (Gold.ToString());
            rewardExperience.text = (Xp.ToString());
            PlayerStats.XP += Xp;
            PlayerStats.Gold += Gold;

            StartCoroutine(DeathDestory());
        }
        else
        {
            StartCoroutine(AnimtionRestart());
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
            case 4:
                if (Alive == true)
                {
                    //yield on a new YieldInstruction that waits for 1 seconds.
                    yield return new WaitForSeconds(1);
                    new WaitForSeconds(1);

                    Animator.Play("BigEdIdle");
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
                playerScript.CurrentHealth -= enemyDamageDone;
                damagePopupTextScript.fadingIn = true;
                damagePopupTextScript.damageDone.text = enemyDamageDone.ToString();
                Debug.Log("Hitplayer");
                playerScript.Hurt();
                StartCoroutine(AnimtionRestart());
                Animator.Play(statHolder.attackAnimation.ToString());
                StartCoroutine(EnemyMeleeAttackAction());

    }
    IEnumerator DeathDestory()
    {

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(2f);
        new WaitForSeconds(2f);

        switch (MonsterType)
        {
            case 1:
                PlayerStats.GoblinsKilled += 1;
                break;
            case 2:
                PlayerStats.SkeletonKilled += 1;
                break;
            case 3:
                PlayerStats.OrcKilled += 1;
                break;
            case 4:
                PlayerStats.GoblinsKilled += 1;
                break;
        }
    }

    public void UIUpdates()
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
        healthBar.Sethealth(currentHealth);
        healthBar.UpdateText(currentHealth);
        ArmourBar.UpdateText(CurrentArmour);
    }

    public void EnemyTurnChoice()
    {
        //PUSHED BOOL
        if (isPushed)
        {
            Pushed();
        }

        //Makes sure that the Enemy hasn't yet chosen anything, otherwise Functions will run once per frame instead of once per turn
        if (!enemyChosenMove && gameManagerScript.enemyTurn == true)
        {
            //Variable used to randomly select whether the Enemy Attacks, Blocks etc....
            enemyChoice = Random.Range(0, 3);

            if (enemyChoice == 0 && Alive == true)
            {
                Attack();
            }
            else if (enemyChoice == 1)
            {
                Block();
            }

            else if (enemyChoice == 2 && Alive == true)
            {
                Move();

            }

        }
    }
}
