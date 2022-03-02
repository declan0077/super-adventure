//script created by Declan Cullen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{

   static public void ChangeLevel()
    {
        if(PlayerStats.Levelup == true)
        {
            SceneManager.LoadScene("Town");
        }
    }

 
}
