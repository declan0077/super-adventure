//script created by Josh Stafford
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Button yourbutton;

    void Start()
    {
        Button btn = yourbutton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        if (PlayerStats.GoblinsKilled == 4 && PlayerStats.GoblinScene == false)
        {
            SceneManager.LoadScene("Story2");
        }
        PlayerStats.Check();
        if (PlayerStats.Levelup == true)
        {
          
                    SceneManager.LoadScene("LevelUpScene");
               
        }
        else
        {
            if (Random.value < 0.5f)
            {
               SceneManager.LoadScene("Encounter");
            }
            else
            {


                if (PlayerStats.Level <= 3)
                {
                    SceneManager.LoadScene("Forest");
                }
                if (PlayerStats.Level >= 3 && PlayerStats.Level < 5)
                {
                    SceneManager.LoadScene("Beach");
                }
                if (PlayerStats.Level >= 5 && PlayerStats.Level < 7)
                {
                    SceneManager.LoadScene("DarkForest");
                }
                if (PlayerStats.Level >= 7 && PlayerStats.Level < 10)
                {
                    SceneManager.LoadScene("Castle");
                }
            }

        }

    }
      
    
}
