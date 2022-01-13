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
        if(PlayerMoney.Levelup == true)
        {
          
                    SceneManager.LoadScene("LevelUpScene");
               
        }
        else
        {
            Debug.Log("You have clicked the button!");
            SceneManager.LoadScene("Town");
        }

    }
      
    
}
