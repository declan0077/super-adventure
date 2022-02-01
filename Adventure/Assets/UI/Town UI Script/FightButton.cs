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
        switch (PlayerStats.Level)
        {
                case 1:
                SceneManager.LoadScene("Forest");
                break;

                case 2:
                SceneManager.LoadScene("Forest");
                break;

                case 3:
                SceneManager.LoadScene("Forest 1");
                break;
            case 4:
                SceneManager.LoadScene("Forest 1");
                break;
            case 5:
                SceneManager.LoadScene("Forest 2");
                break;
        }
       
    }
}
