using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    //MaxHealth of the Player. Default starting number is 20
    private int MaxHealth = 20;
    //The current Health of the player
    public int CurrentHealth;
 
    private int Movementspeed;
    //Max damage the player can deal
    public int MaxDamage;
    //Min damage the palyer can deal
    public int MinimumDamage;
    //Armour ammount
    public int MaxArmour;
    public int CurrentArmour;

    //Reference to the players healthbar
    public Healtbar Healthbar;
    //Reference to the players Armourbar
    public ArmourBar ArmourBar;
    //Gets Reference to the animator
    public Animator Animator;
    //Reference to GameManagerScript
    public GameManager gameManagerScript;
    //Reference to The Players Body 
    public GameObject Body;
    //Reference to The Players Shield 
    public GameObject Shield;
    public Sprite Shield1;
    public Sprite Shield2;
    public Sprite Shield3;
    //Reference to The Players Sword 
    public GameObject Sword;
    public int ExtraDamage;
    public Sprite Sword1;
    public Sprite Sword2;
    public Sprite Sword3;
    //Reference to The Players Spell 
    public GameObject Spell;
    public Sprite spell1;
    public Sprite spell2;
    public Sprite spell3;
    //Reference to The skill check system Used for attacking
    public GameObject SkillCheck;
     int randomchance;

    //Block Defense Value
    public int blockDefense = 0;
    public GameObject blockDefenseIcon;
    public Text blockDefenseValue;


    //Reference to EnemyScript
    public Enemy enemyScript;
    public GameObject enemyPlayer;
    public ParticleSystem Blood;

    //Checks whether the player has selected their move yet or not
    public bool playerChosenMove = false;


    //Block Checker
    public bool blockActive = false;

    //AttackChecker
    public bool attacking = true;

    public MeleeWeaponTrail weaponEffectScript;

    //Reference to text fade script
    public textFade damagePopupTextScript;
    //Player damage UI that appears on Enemy
    public TMP_Text playerDamageUI;

    //Spell checker
    public bool blueSpellPurchased = false;

    //Thorns Upgrade
    public bool redSpellPurchased = false;

    //Leech Upgrade
    public bool greenSpellPurchased = false;


    public int leech = 1;
    public float thornsDamage = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
      
        PlayerStats.ArmourAmount = CurrentArmour;
        CurrentArmour = MaxArmour;
        MaxHealth = MaxHealth + PlayerStats.Constitution;
        CurrentHealth = MaxHealth;
        
      
        Healthbar.Setmaxhealth(MaxHealth);
        Healthbar.UpdateText(CurrentHealth);
        ArmourBar.UpdateText(CurrentArmour);
        ArmourBar.SetmaxArmour(MaxArmour);
   
        Blood.Stop();
        //Sword sprite change
        if (PlayerStats.SwordLevel == 1)
        {
            Sword.GetComponent<SpriteRenderer>().sprite = Sword1;
          
           
        }
        if (PlayerStats.SwordLevel == 2)
        {
            Sword.GetComponent<SpriteRenderer>().sprite = Sword2;
            ExtraDamage = 5;
        }
        if (PlayerStats.SwordLevel == 3)
        {
            Sword.GetComponent<SpriteRenderer>().sprite = Sword3;
         
            ExtraDamage = 10;
        }
        //Shield sprite change
        if (PlayerStats.ShieldLevel == 1)
        {
            Shield.GetComponent<SpriteRenderer>().sprite = Shield1;
            CurrentArmour = 5;
        }
        if (PlayerStats.ShieldLevel == 2)
        {
            Shield.GetComponent<SpriteRenderer>().sprite = Shield2;
            CurrentArmour = 10;
        }
        if (PlayerStats.ShieldLevel == 3)
        {
            Shield.GetComponent<SpriteRenderer>().sprite = Shield3;
            CurrentArmour = 25;
        }
        //Spells sprite change
        if (PlayerStats.SpellLevel == 1)
        {
            Spell.GetComponent<SpriteRenderer>().sprite = spell1;
            blueSpellPurchased = true;
        }
        if (PlayerStats.SpellLevel == 2)
        {
            Spell.GetComponent<SpriteRenderer>().sprite = spell2;
            redSpellPurchased = true;
        }
        if (PlayerStats.SpellLevel == 3)
        {
            Spell.GetComponent<SpriteRenderer>().sprite = spell3;
            greenSpellPurchased = true;
        }
    /*    if (PlayerStats.ArmourLevel == 1)
        {
            Spell.GetComponent<SpriteRenderer>().sprite = spell1;
         
        }
        if (PlayerStats.ArmourLevel == 2)
        {
            Spell.GetComponent<SpriteRenderer>().sprite = spell2;

        }
        if (PlayerStats.ArmourLevel == 3)
        {
            Spell.GetComponent<SpriteRenderer>().sprite = spell3;

        }
    */

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.GoblinsKilled == 3 && PlayerStats.GoblinScene == false)
        {
            SceneManager.LoadScene("Story2");
        }
        if (PlayerStats.SkeletonKilled == 3 &&  PlayerStats.SkeletonScene == false)
        {
            SceneManager.LoadScene("Story3");
        }
        if (PlayerStats.OrcKilled == 3 && PlayerStats.BigEdScene == false)
        {
            SceneManager.LoadScene("Story4");
        }
        if(PlayerStats.BigEdDead == true)
        {
            SceneManager.LoadScene("Story5");
        }

        // Used for testing remove later so it will cause less lag :) xx
        //It should only be called when we are hit to update it
        Healthbar.Sethealth(CurrentHealth);
        Healthbar.UpdateText(CurrentHealth);
        ArmourBar.SetArmour(CurrentArmour);
        ArmourBar.UpdateText(CurrentArmour);
        MaxDamage = 4;
        MinimumDamage = 1;
       
        Movementspeed = 3;

        Debug.DrawLine(Body.transform.position, Body.transform.position + Body.transform.right, Color.blue);

        blockDefenseValue.text = blockDefense.ToString();


        //Disables the block defense UI if not needed
        if(blockDefense <= 0)
        {
            blockDefenseIcon.SetActive(false);
            //Setting it back to 0 allows you to reactivate shield without having to work you way up from negative number
            blockDefense = 0;
        }

        if(blockDefense >= 1)
        {
            blockDefenseIcon.SetActive(true);
        }
        if(CurrentHealth <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
      
    }

    public void Attack()
    {
        if (!playerChosenMove)
        {
            //Stops the player from being able to spam moves in a single turn

            playerChosenMove = true;

            // Attack Code Goes Here

            Debug.Log("Player Chooses Attack");



            //Starts the Coroutine that allows the Attack Animation to play out


            Animator.Play("ReadyPlayer");
            attacking = true;
            RaycastHit2D Hit = Physics2D.Raycast(Body.transform.position, Body.transform.right, 1.5f);
            if (Hit.collider != null && Hit.collider.tag == "Enemy")
            {

                SkillCheck.SetActive(true);

            }
            else if (Hit.collider == null)

            {
                Animator.Play("Attack");
                MissAttack();
               
            }

        }

       
    }
    public void MissAttack()
    {
        randomchance = Random.Range(1, 3);
        if (randomchance == 1)
        {
            Animator.Play("Jumpattack");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());
        }
        if (randomchance == 2)
        {
            Animator.Play("Jumpattack");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());

        }
        if (randomchance == 3)
        {
            Animator.Play("AttackStab");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());

        }
    }
    public void normalattack()
    {
        
        int playerDamageDone = Random.Range(MinimumDamage, MaxDamage);
        int OverallDamage = PlayerStats.Strength + playerDamageDone + ExtraDamage;
        int overDamage = 0;

        //Current Armor = Shield Defense
        //Block Defense = Shield gained from Blocking
        
        //IF ENEMY HAS NO ARMOR AND NO BLOCK SHIELD + PLAYER HAS GREEN AMULET
        if (enemyScript.CurrentArmour <= 0 && enemyScript.blockDefense <= 0 && greenSpellPurchased)
        {
            enemyScript.CurrentHealth -= OverallDamage;
            CurrentHealth += leech;
        }
       
        //IF ENEMY HAS NO ARMOR + NO BLOCK SHIELD + PLAYER HAS NO GREEN AMULET
        else if (enemyScript.CurrentArmour <= 0 && enemyScript.blockDefense <= 0 && !greenSpellPurchased)
        {
            enemyScript.CurrentHealth -= OverallDamage;
        }
        //IF ENEMY HAS ARMOR + NO BLOCK SHIELD + PLAYER HAS GREEN AMULET
        else if (enemyScript.CurrentArmour > 0 && enemyScript.blockDefense == 0 && greenSpellPurchased)
        {
            if(OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.CurrentHealth -= overDamage;
                enemyScript.CurrentArmour = 0;
                CurrentHealth += leech;
            }
            else if(OverallDamage < enemyScript.blockDefense)
            {
                enemyScript.blockDefense -= OverallDamage;
            }
        }
        //IF ENEMY HAS ARMOR + NO BLOCK SHIELD + PLAYER HAS NO GREEN AMULET
        else if (enemyScript.CurrentArmour > 0 && enemyScript.blockDefense == 0 && !greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.CurrentArmour)
            {
                overDamage = OverallDamage - enemyScript.CurrentArmour;
                enemyScript.CurrentArmour = 0;
                enemyScript.CurrentHealth -= overDamage;
            }
            else if (OverallDamage < enemyScript.CurrentArmour)
            {
                enemyScript.CurrentArmour -= OverallDamage;
            }
        }
        //IF ENEMY HAS NO ARMOR + BLOCK SHIELD + PLAYER HAS GREEN AMULET
        else if(enemyScript.CurrentArmour == 0 && enemyScript.blockDefense > 0 && greenSpellPurchased)
        {
            if(OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.CurrentHealth -= overDamage;
                enemyScript.blockDefense = 0;
                CurrentHealth += leech;
            }
            else if(OverallDamage < enemyScript.blockDefense)
            {
                enemyScript.blockDefense -= OverallDamage;
            }
        }
        //IF ENEMY HAS NO ARMOR + BLOCK SHIELD + PLAYER HAS NO GREEN AMULET
        else if (enemyScript.CurrentArmour == 0 && enemyScript.blockDefense > 0 && !greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.blockDefense = 0;
                enemyScript.CurrentHealth -= overDamage;
            }
            else if (OverallDamage < enemyScript.blockDefense)
            {
                enemyScript.blockDefense -= OverallDamage;
            }
        }
        //IF ENEMY HAS ARMOR AND BLOCK SHIELD + PLAYER HAS GREEN AMULET
        else if(enemyScript.CurrentArmour > 0 && enemyScript.blockDefense > 0 && greenSpellPurchased)
        {
            if(OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.blockDefense = 0;
                
                if(overDamage > enemyScript.CurrentArmour)
                {
                    overDamage  -= enemyScript.CurrentArmour;
                    enemyScript.CurrentArmour = 0;
                    enemyScript.CurrentHealth -= overDamage;
                    enemyScript.CurrentHealth += leech;
                }
                else if(overDamage < enemyScript.CurrentArmour)
                {
                    enemyScript.CurrentArmour -= overDamage;
                }
                        
            }
        }
        //IF ENEMY HAS ARMOR AND BLOCK SHIELD + PLAYER HAS NO GREEN AMULET
        else if (enemyScript.CurrentArmour > 0 && enemyScript.blockDefense > 0 && !greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.blockDefense = 0;

                if (overDamage > enemyScript.CurrentArmour)
                {
                    overDamage -= enemyScript.CurrentArmour;
                    enemyScript.CurrentArmour = 0;
                    enemyScript.CurrentHealth -= overDamage;
                 
                }
                else if (overDamage < enemyScript.CurrentArmour)
                {
                    enemyScript.CurrentArmour -= overDamage;
                }

            }
        }


        damagePopupTextScript.fadingIn = true;
        damagePopupTextScript.damageDone.text = OverallDamage.ToString();
        Debug.Log("HitYa");
        enemyScript.Hurt();
        randomchance = Random.Range(1, 3);
        if(randomchance == 1)
        {
            Animator.Play("Attack");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());
        }
        if (randomchance == 2)
        {
            Animator.Play("Jumpattack");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());
            
        }
        else
        {
            Animator.Play("AttackStab");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());
        }
      
    }
    public void CritAttack()
    {

        int playerDamageDone = Random.Range(MinimumDamage, MaxDamage);
        int OverallDamage = PlayerStats.Strength + playerDamageDone + ExtraDamage * 2;
        int overDamage = 0;

        //Current Armor = Shield Defense
        //Block Defense = Shield gained from Blocking

        //IF ENEMY HAS NO ARMOR AND NO BLOCK SHIELD + PLAYER HAS GREEN AMULET
        if (enemyScript.CurrentArmour <= 0 && enemyScript.blockDefense <= 0 && greenSpellPurchased)
        {
            enemyScript.CurrentHealth -= OverallDamage;
            CurrentHealth += leech;
        }

        //IF ENEMY HAS NO ARMOR + NO BLOCK SHIELD + PLAYER HAS NO GREEN AMULET
        else if (enemyScript.CurrentArmour <= 0 && enemyScript.blockDefense <= 0 && !greenSpellPurchased)
        {
            enemyScript.CurrentHealth -= OverallDamage;
        }
        //IF ENEMY HAS ARMOR + NO BLOCK SHIELD + PLAYER HAS GREEN AMULET
        else if (enemyScript.CurrentArmour > 0 && enemyScript.blockDefense == 0 && greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.CurrentHealth -= overDamage;
                enemyScript.CurrentArmour = 0;
                CurrentHealth += leech;
            }
            else if (OverallDamage < enemyScript.blockDefense)
            {
                enemyScript.blockDefense -= OverallDamage;
            }
        }
        //IF ENEMY HAS ARMOR + NO BLOCK SHIELD + PLAYER HAS NO GREEN AMULET
        else if (enemyScript.CurrentArmour > 0 && enemyScript.blockDefense == 0 && !greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.CurrentArmour)
            {
                overDamage = OverallDamage - enemyScript.CurrentArmour;
                enemyScript.CurrentArmour = 0;
                enemyScript.CurrentHealth -= overDamage;
            }
            else if (OverallDamage < enemyScript.CurrentArmour)
            {
                enemyScript.CurrentArmour -= OverallDamage;
            }
        }
        //IF ENEMY HAS NO ARMOR + BLOCK SHIELD + PLAYER HAS GREEN AMULET
        else if (enemyScript.CurrentArmour == 0 && enemyScript.blockDefense > 0 && greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.CurrentHealth -= overDamage;
                enemyScript.blockDefense = 0;
                CurrentHealth += leech;
            }
            else if (OverallDamage < enemyScript.blockDefense)
            {
                enemyScript.blockDefense -= OverallDamage;
            }
        }
        //IF ENEMY HAS NO ARMOR + BLOCK SHIELD + PLAYER HAS NO GREEN AMULET
        else if (enemyScript.CurrentArmour == 0 && enemyScript.blockDefense > 0 && !greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.blockDefense = 0;
                enemyScript.CurrentHealth -= overDamage;
            }
            else if (OverallDamage < enemyScript.blockDefense)
            {
                enemyScript.blockDefense -= OverallDamage;
            }
        }
        //IF ENEMY HAS ARMOR AND BLOCK SHIELD + PLAYER HAS GREEN AMULET
        else if (enemyScript.CurrentArmour > 0 && enemyScript.blockDefense > 0 && greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.blockDefense = 0;

                if (overDamage > enemyScript.CurrentArmour)
                {
                    overDamage -= enemyScript.CurrentArmour;
                    enemyScript.CurrentArmour = 0;
                    enemyScript.CurrentHealth -= overDamage;
                    CurrentHealth += leech;
                }
                else if (overDamage < enemyScript.CurrentArmour)
                {
                    enemyScript.CurrentArmour -= overDamage;
                }

            }
            else if (OverallDamage < enemyScript.blockDefense)
            {
                enemyScript.blockDefense -= OverallDamage;
            }
        }
        //IF ENEMY HAS ARMOR AND BLOCK SHIELD + PLAYER HAS NO GREEN AMULET
        else if (enemyScript.CurrentArmour > 0 && enemyScript.blockDefense > 0 && !greenSpellPurchased)
        {
            if (OverallDamage > enemyScript.blockDefense)
            {
                overDamage = OverallDamage - enemyScript.blockDefense;
                enemyScript.blockDefense = 0;

                if (overDamage > enemyScript.CurrentArmour)
                {
                    overDamage -= enemyScript.CurrentArmour;
                    enemyScript.CurrentArmour = 0;
                    enemyScript.CurrentHealth -= overDamage;

                }
                else if (overDamage < enemyScript.CurrentArmour)
                {
                    enemyScript.CurrentArmour -= overDamage;
                }

            }else if(OverallDamage < enemyScript.blockDefense)
            {
                enemyScript.blockDefense -= OverallDamage;
            }
        }


        damagePopupTextScript.fadingIn = true;
        damagePopupTextScript.damageDone.text = OverallDamage.ToString();
        Debug.Log("HitYa");
        enemyScript.Hurt();
        randomchance = Random.Range(1, 3);
        if (randomchance == 1)
        {
            Animator.Play("Attack");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());
        }
        if (randomchance == 2)
        {
            Animator.Play("Jumpattack");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());

        }
        else
        {
            Animator.Play("AttackStab");
            weaponEffectScript.Emit = true;
            StartCoroutine(AttackAction());
        }

    }
    public void Block()
    {

        if (!playerChosenMove)
        {
            //blockActive = true;
            blockDefense += 1;
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
            playerChosenMove = true;
            RaycastHit2D Hit = Physics2D.Raycast(Body.transform.position, Body.transform.right, 1.5f);
            //Ray Check to make sure you're in Melee range to push the Enemy.
            if (Hit.collider != null && Hit.collider.tag == "Enemy")
            {
                //Stops the player from being able to spam moves in a single turn
                Debug.Log("Player Chooses Push");
                //Checks whether the Enemy has been pushed. Bool activates Pushed function in Player Script.
                enemyScript.isPushed = true;
                StartCoroutine(AttackAction());
                Animator.Play("Push");
                //Gives the enemy their turn Plus restarts the animations
                StartCoroutine(AnimtionRestart());
            }
            else if (Hit.collider == null)

            {
                Animator.Play("Push");
                StartCoroutine(AttackAction());

                StartCoroutine(AnimtionRestart());

            }

        }
    }

    public void Hurt()
    {

        Animator.Play("PlayerHurt");
        Blood.Play();
        StartCoroutine(AnimtionRestart());
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = Color.red;
        }
        StartCoroutine(HurtFlash());
    }

    IEnumerator AttackAction()
    {

        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(1);
        Debug.Log("PlayersTurnOver");

        //Swaps turns after the Attack is done by the player
        gameManagerScript.playerTurn = false;
        gameManagerScript.enemyTurn = true;

        //Changes bool so that the Enemy is able to choose a move for their turn
        enemyScript.enemyChosenMove = false;
        //Removes the Weapon Slash effect particle system when the Player stops attack animation.
        weaponEffectScript.Emit = false;

    }
    IEnumerator AnimtionRestart()
    {

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        new WaitForSeconds(1);

        Animator.Play("PlayerCharacter");
        Blood.Stop();
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


}
