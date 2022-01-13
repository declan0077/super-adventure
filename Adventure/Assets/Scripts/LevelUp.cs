using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{

   static public void ChangeLevel()
    {
        if(PlayerMoney.Levelup == true)
        {
            SceneManager.LoadScene("Town");
        }
    }

 
}
