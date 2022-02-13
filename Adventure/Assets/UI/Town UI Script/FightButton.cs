using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FightButton : MonoBehaviour
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

