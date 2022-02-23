using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    static public int Gold = 10000;
    static public int XP = 0;
    static public int Level = 1;
    static public int LevelupCost = 50;
    static public int statupgrade = 0;
    static public bool Levelup = false;
    static public int ShieldLevel;
    static public int ArmourLevel;
    static public int SwordLevel;
    static public int SpellLevel;
    //Checks if the player has seen the goblin storyline
    static public bool GoblinScene = false;
    //Numbers of enemy killed
    static public int GoblinsKilled;
    //Checks if the player has seen the skeleton storyline
    static public bool SkeletonScene = false;
    //Numbers of enemy killed
    static public int SkeletonKilled;
    //Checks if the player has seen the bigedstart storyline
    static public bool BigEdScene = false;
    //Numbers of enemy killed
    static public int OrcKilled;
    //Checks if the player has killed biged
    static public bool BigEdDead = false;
    //Player Stats
    static public int Strength = 0;
    static public int Agility = 0;
    static public int Constitution = 0;
    static public int Intelligence = 0;
    static public int Charisma = 0;

    //Player Appearance
    static public bool Male;
    static public int Race;
    static public Color Skincolour;
    //Human = 1 Elf = 2 Orc = 3 catperson = 4



    //Shield
    static public int Shield = 0;
    //Shield Armour gets applied to the player
    static public int ArmourAmount;

    //Sword

    static public int Sword = 0;


    //TRAITS

    //Good Traits
    public int goodTraitsChosen = 0;
    public bool isCareful = false;
    public bool isAdaptive = false;
    public bool isIntelligent = false;
    public bool isCharming = false;
    public bool isTough = false;
    public bool isFearless = false;

    //Bad Traits
    public int badTraitsChosen = 0;
    public bool isCareless = false;
    public bool isClumsy = false;
    public bool isLazy = false;
    public bool isAfraid = false;
    public bool isArrogant = false;
    public bool isSelfish = false;

    public GameObject isCarefulTickSymbol;
    public GameObject isAdaptiveTickSymbol;
    public GameObject isIntelligentTickSymbol;
    public GameObject isCharmingTickSymbol;
    public GameObject isToughTickSymbol;
    public GameObject isFearlessTickSymbol;
    public GameObject isCarelessTickSymbol;
    public GameObject isClumsyTickSymbol;
    public GameObject isLazyTickSymbol;
    public GameObject isAfraidTickSymbol;
    public GameObject isArrogantTickSymbol;
    public GameObject isSelfishTickSymbol;

    public GameObject confirmButton;
    //Keeps the traits running throughout the game
    public void Update()
    {
        if(goodTraitsChosen == 3 && badTraitsChosen == 3)
        {
            confirmButton.SetActive(true);
        }
        else
        {
            confirmButton.SetActive(false);
        }
    }

    public static void Check()
    {
        if(XP >= LevelupCost)
        {
            Level += 1;
            LevelupCost += 100;
            statupgrade += 1;
            Debug.Log("levelup");
            Levelup = true;
            XP = 0;
        }


    }

    public static void ShieldCheck()
    {
        switch(Shield)
        {
            case 0:
                Debug.Log("Empty");
                break;

            case 1:
                if (Gold >= 10 && ShieldLevel < 1)
                {
                    Gold -= 10;
                    Debug.Log("You bought a Round Shield");
                    ShieldLevel = 1;
                    ArmourAmount = 5;
                    break;
                }
                else
                {
                    Debug.Log("Not enough money or you have better");
                    break;
                }
            case 2:
                if (Gold >= 100 && ShieldLevel < 2)
                {
                    Gold -= 100;
                    Debug.Log("You bought a Kite Shield");
                    ShieldLevel = 2;
                    ArmourAmount = 15;
                    break;
                }
                else
                {
                    Debug.Log("Not enough money or you have better");
                    break;
                }
            case 3:
                if (Gold >= 1000 && ShieldLevel < 3)
                {
                    Gold -= 1000;
                    Debug.Log("You bought a Tower Shield");
                    ShieldLevel = 3;
                    ArmourAmount = 30;
                    break;
                }
                else
                {
                    Debug.Log("Not enough money or you have better");
                    break;
                }
            default:
                Debug.Log("Round Shield");
                break;
        }
    }



    public void CarefulTraitSelected()
    {
        if(isCareful == false && goodTraitsChosen >= 0 && goodTraitsChosen < 3)
        {
            isCareful = true;
            goodTraitsChosen += 1;
            isCarefulTickSymbol.SetActive(true);
        }else if(isCareful == true)
        {
            isCareful = false;
            goodTraitsChosen -= 1;
            isCarefulTickSymbol.SetActive(false);
        }

    }
    public void AdaptiveTraitSelected()
    {
        if (isAdaptive == false && goodTraitsChosen >= 0 && goodTraitsChosen < 3)
        {
            isAdaptive = true;
            goodTraitsChosen += 1;
            isAdaptiveTickSymbol.SetActive(true);
        }
        else if (isAdaptive == true)
        {
            isAdaptive = false;
            goodTraitsChosen -= 1;
            isAdaptiveTickSymbol.SetActive(false);
        }
    }
    public void IntelligentTraitSelected()
    {
        if (isIntelligent == false && goodTraitsChosen >= 0 && goodTraitsChosen < 3)
        {
            isIntelligent = true;
            goodTraitsChosen += 1;
            isIntelligentTickSymbol.SetActive(true);
        }
        else if (isIntelligent == true)
        {
            isIntelligent = false;
            goodTraitsChosen -= 1;
            isIntelligentTickSymbol.SetActive(false);
        }
    }
    public void CharmingTraitSelected()
    {
        if (isCharming == false && goodTraitsChosen >= 0 && goodTraitsChosen < 3)
        {
            isCharming = true;
            goodTraitsChosen += 1;
            isCharmingTickSymbol.SetActive(true);
        }
        else if (isCharming == true)
        {
            isCharming = false;
            goodTraitsChosen -= 1;
            isCharmingTickSymbol.SetActive(false);
        }
    }
    public void ToughTraitSelected()
    {
        if (isTough == false && goodTraitsChosen >= 0 && goodTraitsChosen < 3)
        {
            isTough = true;
            goodTraitsChosen += 1;
            isToughTickSymbol.SetActive(true);
        }
        else if (isTough == true)
        {
            isTough = false;
            goodTraitsChosen -= 1;
            isToughTickSymbol.SetActive(false);
        }
    }
    public void FearlessTraitSelected()
    {
        if (isFearless == false && goodTraitsChosen >= 0 && goodTraitsChosen < 3)
        {
            isFearless = true;
            goodTraitsChosen += 1;
            isFearlessTickSymbol.SetActive(true);
        }
        else if (isFearless == true)
        {
            isFearless = false;
            goodTraitsChosen -= 1;
            isFearlessTickSymbol.SetActive(false);
        }
    }
    public void CarelessTraitSelected()
    {
        if (isCareless == false && badTraitsChosen >= 0 && badTraitsChosen < 3)
        {
            isCareless = true;
            badTraitsChosen += 1;
            isCarelessTickSymbol.SetActive(true);
        }
        else if (isCareless == true)
        {
            isCareless = false;
            badTraitsChosen -= 1;
            isCarelessTickSymbol.SetActive(false);
        }
    }
    public void ClumsyTraitSelected()
    {
        if (isClumsy == false && badTraitsChosen >= 0 && badTraitsChosen < 3)
        {
            isClumsy = true;
            badTraitsChosen += 1;
            isClumsyTickSymbol.SetActive(true);
        }
        else if (isClumsy == true)
        {
            isClumsy = false;
            badTraitsChosen -= 1;
            isClumsyTickSymbol.SetActive(false);
        }
    }
    public void LazyTraitSelected()
    {
        if (isLazy == false && badTraitsChosen >= 0 && badTraitsChosen < 3)
        {
            isLazy = true;
            badTraitsChosen += 1;
            isLazyTickSymbol.SetActive(true);
        }
        else if (isLazy == true)
        {
            isLazy = false;
            badTraitsChosen -= 1;
            isLazyTickSymbol.SetActive(false);
        }
    }
    public void AfraidTraitSelected()
    {
        if (isAfraid == false && badTraitsChosen >= 0 && badTraitsChosen < 3)
        {
            isAfraid = true;
            badTraitsChosen += 1;
            isAfraidTickSymbol.SetActive(true);
        }
        else if (isAfraid == true)
        {
            isAfraid = false;
            badTraitsChosen -= 1;
            isAfraidTickSymbol.SetActive(false);
        }

    }
    public void ArrogantTraitSelected()
    {
        if (isArrogant == false && badTraitsChosen >= 0 && badTraitsChosen < 3)
        {
            isArrogant = true;
            badTraitsChosen += 1;
            isArrogantTickSymbol.SetActive(true);
        }
        else if (isArrogant == true)
        {
            isArrogant = false;
            badTraitsChosen -= 1;
            isArrogantTickSymbol.SetActive(false);
        }
    }
    public void SelfishTraitSelected()
    {
        if (isSelfish == false && badTraitsChosen >= 0 && badTraitsChosen < 3)
        {
            isSelfish = true;
            badTraitsChosen += 1;
            isSelfishTickSymbol.SetActive(true);
        }
        else if (isSelfish == true)
        {
            isSelfish = false;
            badTraitsChosen -= 1;
            isSelfishTickSymbol.SetActive(false);
        }
    }

}
