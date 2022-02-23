using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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

    public MeleeWeaponTrail weaponEffectScript;

    public AudioSource[] malePlayerHurt;
    public AudioSource[] femalePlayerHurt;

    public int enemyDamageDone;
    public int overDamage = 0;

    public bool isPushed = false;


    //Turn UI to disable when round ends
    public GameObject whosTurn;



    // Start is called before the first frame update
    void Start()
    {

        switch (MonsterType)
        {
            case 1:
                enemyDamageDone = Random.Range(1, 6);
                MaxHealth = Random.Range(6, 12);
                Healthbar.Setmaxhealth(MaxHealth);
                Healthbar.UpdateText(CurrentHealth);
                CurrentHealth = MaxHealth;
                JumpPower = 5;
                MovementSpeed = 4;
                Blood.Stop();
                Gold = Random.Range(40, 80);
                Xp = Random.Range(50, 100);
                ArmourBar.SetmaxArmour(MaxArmour);
                ArmourBar.UpdateText(CurrentArmour);
                CurrentArmour = MaxArmour;

                break;
            case 2:
                enemyDamageDone = Random.Range(2, 10);
                MaxHealth = Random.Range(12, 24);
                Healthbar.Setmaxhealth(MaxHealth);
                Healthbar.UpdateText(CurrentHealth);
                CurrentHealth = MaxHealth;
                JumpPower = 5;
                MovementSpeed = 3;
                Blood.Stop();
                Gold = Random.Range(100, 200);
                Xp = Random.Range(200, 300);
                MaxArmour = 5;
                ArmourBar.SetmaxArmour(MaxArmour);
                ArmourBar.UpdateText(CurrentArmour);
                CurrentArmour = MaxArmour;
                break;
            case 3:
                enemyDamageDone = Random.Range(6, 14);
                MaxHealth = Random.Range(24, 48);
                Healthbar.Setmaxhealth(MaxHealth);
                Healthbar.UpdateText(CurrentHealth);
                CurrentHealth = MaxHealth;
                JumpPower = 5;
                MovementSpeed = 3;
                Blood.Stop();
                Gold = Random.Range(400, 600);  
                Xp = Random.Range(500, 700);
                MaxArmour = 10;
                ArmourBar.SetmaxArmour(MaxArmour);
                ArmourBar.UpdateText(CurrentArmour);
                CurrentArmour = MaxArmour;
                break;
            case 4:
                enemyDamageDone = Random.Range(10, 16);
                MaxHealth = Random.Range(100, 100);
                Healthbar.Setmaxhealth(MaxHealth);
                Healthbar.UpdateText(CurrentHealth);
                CurrentHealth = MaxHealth;
                JumpPower = 5;
                MovementSpeed = 4;
                Blood.Stop();
                Gold = Random.Range(1000, 6000);
                Xp = Random.Range(6000, 6000);
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

        //PUSHED BOOL
        if (isPushed)
        {
            Pushed();
        }

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

            if (enemyChoice == 0 && Alive == true)
            {
                Attack();
            }
            else if (enemyChoice == 1)
            {
                Block();
            }
            else
            {

            }
            if (enemyChoice == 2 && Alive == true)
            {
                Move();

            }
            if (enemyChoice == 3 && Alive == true)
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
        if (Inrange.collider != null && Inrange.collider.tag == "Player")
        {
            PlayerInrange = true;
        }
        else if (Inrange.collider == null)
        {
            PlayerInrange = false;
        }
    }
    public void Deathaction()
    {
        enemyChosenMove = true;
    }
    public void Attack()
    {
        enemyChosenMove = true;
        // Attack Code Goes Here
        StartCoroutine(EnemyMeleeAttackAction());



        RaycastHit2D Hit = Physics2D.Raycast(Body.transform.position, -Body.transform.right, 1.5f);

        //Damage conditions for Enemy to damage player
        switch (MonsterType)
        {
            case 1:

                int OverallDamage = Random.Range(1,6);

                if (Hit.collider != null && Hit.collider.tag == "Player")
                {

                    //IF PLAYER HAS NO ARMOR AND NO BLOCK SHIELD + PLAYER HAS RED AMULET
                    if (playerScript.CurrentArmour <= 0 && playerScript.blockDefense == 0 && playerScript.redSpellPurchased == true)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                        CurrentHealth -= 1;
                        if (PlayerStats.Male)
                        {
                            malePlayerHurt[Random.Range(0,malePlayerHurt.Length)].Play();
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
                    else if (playerScript.CurrentArmour > 0 && playerScript.blockDefense  == 0 && playerScript.redSpellPurchased == true)
                    {
                        if (OverallDamage > playerScript.CurrentArmour)
                        {
                            overDamage = OverallDamage - playerScript.CurrentArmour;
                            playerScript.CurrentHealth -= overDamage;
                            CurrentHealth -= 1;
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
                            CurrentHealth -= 1;
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
                                CurrentHealth -= 1;
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

                        }else if(OverallDamage <= playerScript.blockDefense)
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
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("GoblinAttack");
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
                break;
            case 2:


                OverallDamage = Random.Range(2,10);

                if (Hit.collider != null && Hit.collider.tag == "Player")
                {

                    //IF PLAYER HAS NO ARMOR AND NO BLOCK SHIELD + PLAYER HAS RED AMULET
                    if (playerScript.CurrentArmour <= 0 && playerScript.blockDefense == 0 && playerScript.redSpellPurchased == true)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                        CurrentHealth -= 1;
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
                            CurrentHealth -= 1;
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
                            CurrentHealth -= 1;
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
                                CurrentHealth -= 1;
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
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("SkeletonAttack");
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
                break;
            case 3:


                 OverallDamage = Random.Range(6, 14);

                if (Hit.collider != null && Hit.collider.tag == "Player")
                {

                    //IF PLAYER HAS NO ARMOR AND NO BLOCK SHIELD + PLAYER HAS RED AMULET
                    if (playerScript.CurrentArmour <= 0 && playerScript.blockDefense == 0 && playerScript.redSpellPurchased == true)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                        CurrentHealth -= 1;
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
                            CurrentHealth -= 1;
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
                        else if (OverallDamage <= playerScript.blockDefense)
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
                            CurrentHealth -= 1;
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
                                CurrentHealth -= 1;
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
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("OrcAttack");
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
                break;
            case 4:


                OverallDamage = Random.Range(9, 20);

                if (Hit.collider != null && Hit.collider.tag == "Player")
                {

                    //IF PLAYER HAS NO ARMOR AND NO BLOCK SHIELD + PLAYER HAS RED AMULET
                    if (playerScript.CurrentArmour <= 0 && playerScript.blockDefense == 0 && playerScript.redSpellPurchased == true)
                    {
                        playerScript.CurrentHealth -= enemyDamageDone;
                        CurrentHealth -= 1;
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
                            playerScript.CurrentArmour = 0;
                            CurrentHealth -= 1;
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
                            CurrentHealth -= 1;
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
                                CurrentHealth -= 1;
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
                    Debug.Log("Hitplayer");
                    playerScript.Hurt();
                    StartCoroutine(AnimtionRestart());
                    Animator.Play("BigEdAttack");
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
                    blockDefense += 1;

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
                    blockDefense += 1;
                    StartCoroutine(EnemyMeleeAttackAction());
                    StartCoroutine(AnimtionRestart());
                }
                else
                {
                    Getcloser();
                }
                break;
            case 4:
                if (PlayerInrange == true)
                {
                    enemyChosenMove = true;
                    Animator.Play("BigEdBlock");
                    //Block Code Goes Here

                    Debug.Log("Enemy Chooses Block");
                    blockDefense += 2;
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
            case 4:
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
                        Animator.Play("BigEdMove");
                        GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
                        //Starts the Coroutine that allows the Attack Animation to play out
                        StartCoroutine(EnemyMeleeAttackAction());
                        StartCoroutine(AnimtionRestart());
                    }

                }
                break;
        }

    }
    
    public void Pushed() {
        switch (MonsterType)
        {
            case 1:
                //Move Code Goes Here
                if (isPushed)
                {
                    { 
                        Debug.Log("Enemy Pushed");
                        Animator.Play("GoblinWalk");
                        //Forces the Enemy back 2 spaces
                        GetComponent<Rigidbody2D>().velocity = (Vector2.right * 2) * MovementSpeed;
                        isPushed = false;
                    }
                }
                break;
            case 2:
                
                if (isPushed)
                {
                    { 
                    Debug.Log("Enemy Pushede");
                    Animator.Play("SkeletonWalk");
                        GetComponent<Rigidbody2D>().velocity = (Vector2.right * 2) * MovementSpeed;
                        isPushed = false;
                }

                }
                break;
            case 3:
                if (isPushed)
                {
                    {
                        Debug.Log("Enemy Pushede");
                        Animator.Play("OrcWalk");
                        GetComponent<Rigidbody2D>().velocity = (Vector2.right * 2) * MovementSpeed;
                        isPushed = false;
                    }

                }
                break;
            case 4:
                if (isPushed)
                {
                    {
                        Debug.Log("Enemy Pushede");
                        Animator.Play("BigEdWalk");
                   
                        GetComponent<Rigidbody2D>().velocity = (Vector2.right * 2) * MovementSpeed;
                        isPushed = false;
                    }

                }
                break;
        }
    }
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
            case 4:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * MovementSpeed;
                Animator.Play("BigEdMove");
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
            weaponEffectScript.Emit = false;
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
            case 4:
                Death();
                Animator.Play("BigEdHurt");
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
        switch (MonsterType)
        {
            case 1:
                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                    enemyDamageDone = 0;
                    Healthbar.UpdateText(CurrentHealth);
                    Alive = false;
                    Blood.Play();
                    Animator.Play("GoblinDead");
                    Delay();
                    Debug.Log("Dead");
                    RewardText.SetActive(true);
                    RewardText.GetComponent<Animator>().Play("RewardSlideIn");
                    whosTurn.SetActive(false);
                    Rewardgold.text = (Gold.ToString());
                    RewardXp.text = (Xp.ToString());
                    PlayerStats.XP += Xp;
                    PlayerStats.Gold += Gold;
                
                    StartCoroutine(DeathDestory());

                }
                else
                {
                    StartCoroutine(AnimtionRestart());
                }
                break;
            case 2:
                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                    enemyDamageDone = 0;
                    Healthbar.UpdateText(CurrentHealth);
                    Alive = false;
          
                    Blood.Play();
                    Animator.Play("Skeletondead");
                    Delay();
                    Debug.Log("Dead");
                    RewardText.SetActive(true);
                    RewardText.GetComponent<Animator>().Play("RewardSlideIn");
                    whosTurn.SetActive(false);
                    Rewardgold.text = (Gold.ToString());
                    RewardXp.text = (Xp.ToString());
                    PlayerStats.XP += Xp;
                    PlayerStats.Gold += Gold;
                    StartCoroutine(DeathDestory());

                }
                else
                {
                    StartCoroutine(AnimtionRestart());
                }
                break;
            case 3:
                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                    enemyDamageDone = 0;
                    Healthbar.UpdateText(CurrentHealth);
                    Alive = false;

                    Blood.Play();
                    Animator.Play("OrcDead");
                    Delay();
                    Debug.Log("Dead");
                    RewardText.SetActive(true);
                    RewardText.GetComponent<Animator>().Play("RewardSlideIn");
                    whosTurn.SetActive(false);
                    Rewardgold.text = (Gold.ToString());
                    RewardXp.text = (Xp.ToString());
                    PlayerStats.XP += Xp;
                    PlayerStats.Gold += Gold;
                    StartCoroutine(DeathDestory());

                }
                else
                {
                    StartCoroutine(AnimtionRestart());
                }
                break;
            case 4:
                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                    enemyDamageDone = 0;
                    Healthbar.UpdateText(CurrentHealth);
                    Alive = false;
                    Blood.Play();
                    Animator.Play("BigEdDeath");
                    Delay();
                    Debug.Log("Dead");
                    RewardText.SetActive(true);
                    RewardText.GetComponent<Animator>().Play("RewardSlideIn");
                    whosTurn.SetActive(false);
                    Rewardgold.text = (Gold.ToString());
                    RewardXp.text = (Xp.ToString());
                    PlayerStats.XP += Xp;
                    PlayerStats.Gold += Gold;
                    StartCoroutine(DeathDestory());
                    PlayerStats.BigEdDead = true;

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
            case 4:


                int BigEdDamage = Random.Range(4, 24);
                playerScript.CurrentHealth -= BigEdDamage;
                damagePopupTextScript.fadingIn = true;
                damagePopupTextScript.damageDone.text = BigEdDamage.ToString();
                Debug.Log("Hitplayer");
                playerScript.Hurt();
                StartCoroutine(AnimtionRestart());
                Animator.Play("BigEdAttack");
                StartCoroutine(EnemyMeleeAttackAction());

                break;
        }

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
}
