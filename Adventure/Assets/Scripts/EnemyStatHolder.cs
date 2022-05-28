using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy")]
public class EnemyStatHolder : ScriptableObject
{
    //Primary stats for enemy
    public int health;
    public int damage;

    //Secondary stats for enemy
    public int moveSpeed;
    public int armor;

    //Drop amounts for enemies
    public int xpGiven;
    public int goldGiven;

    //Animations
    public string attackAnimation;
    public string blockAnimation;
    public string walkAnimation;
    public string hurtAnimation;
    public string deathAnimation;

    //Audio
    public AudioSource  [] vocalSounds;

}
