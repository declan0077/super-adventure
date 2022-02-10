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
                if (PlayerStats.Level > 3 && PlayerStats.Level < 5)
                {
                    SceneManager.LoadScene("Beach");
                }
            }

        }

    }
      
    
}
