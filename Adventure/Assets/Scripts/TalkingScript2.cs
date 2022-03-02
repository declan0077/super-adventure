//script created by Declan Cullen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TalkingScript2 : MonoBehaviour
{
    public int TextNumber;
    public Sprite Goblin;
    public Sprite Player;
    public Sprite FemalePlayer;
    public TMP_Text Text;
    public TMP_Text Name;
    public Image uichar;
    public string playerName;
    // Start is called before the first frame update
    public void Textupdate()
    {
        TextNumber += 1;
    }

    // Update is called once per frame
    void Update()
    {
        playerName = MainMenu.playersName;
        switch (TextNumber)
        {
            case 0:
                uichar.GetComponent<Image>().sprite = Goblin;
                Name.text = ("Goblin:");
                Text.text = ("Ah Dont hurt me.");
                break;
            case 1:
                if (PlayerStats.Male == true)
                {
                    uichar.GetComponent<Image>().sprite = Player;
                }
                else
                {
                    uichar.GetComponent<Image>().sprite = FemalePlayer;
                }
                Name.text = (playerName + ": ");
                Text.text = ("What are you doing in these forests?");
                break;
            case 2:
                uichar.GetComponent<Image>().sprite = Goblin;
                Name.text = ("Goblin:");
                Text.text = ("I was just.... having a morning walk. Yes just a walk.");
                break;
            case 3:
                if (PlayerStats.Male == true)
                {
                    uichar.GetComponent<Image>().sprite = Player;
                }
                else
                {
                    uichar.GetComponent<Image>().sprite = FemalePlayer;
                }
                Name.text = (playerName + ": ");
                Text.text = ("That's not going to fly, where is the princess!");
                break;
            case 4:
                uichar.GetComponent<Image>().sprite = Goblin;
                Name.text = ("Goblin:");
                Text.text = ("*Sigh* Well as you spared me my life.. She was taken to the beach cove.");
                break;
            case 5:
                uichar.GetComponent<Image>().sprite = Goblin;
                Name.text = ("Goblin:");
                PlayerStats.GoblinScene = true;
                SceneManager.LoadScene("Town");
             
                break;

        }
    }
}
