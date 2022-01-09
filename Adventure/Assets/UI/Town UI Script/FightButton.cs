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
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene("SampleScene");
    }
}
