using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TalkingScript3 : MonoBehaviour
{
    public int TextNumber;
    public Sprite Skeleton;
    public Sprite Player;
    public Sprite FemalePlayer;
    public Sprite scroll;
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
                uichar.GetComponent<Image>().sprite = Skeleton;
                Name.text = ("Skeleton:");
                Text.text = ("kha kha kha");
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
                Text.text = ("*Bonk!* Hits skeleton!");
                break;
            case 2:
                uichar.GetComponent<Image>().sprite = Skeleton;
                Name.text = ("Crumbling skeleton:");
                Text.text = ("*Crumbles*");
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
                Text.text = ("There is no sign of the princess here, where could she of gone");
                break;
            case 4:
                if (PlayerStats.Male == true)
                {
                    uichar.GetComponent<Image>().sprite = Player;
                }
                else
                {
                    uichar.GetComponent<Image>().sprite = FemalePlayer;
                }
                Name.text = (playerName + ": ");
                Text.text = ("Whats that over there?! Is that a scroll");
                break;
            case 5:
                uichar.GetComponent<Image>().sprite = scroll;
                Name.text = ("Scroll:");
                Text.text = ("By order of Ed the overlord, Take her to the castle");
                Text.color = Color.red;
                
                PlayerStats.SkeletonScene = true;
                break;
            case 6:
                uichar.GetComponent<Image>().sprite = scroll;
                Name.text = ("Scroll:");
                Text.text = ("By order of Ed the overlord, Take her to the castle");
                Text.color = Color.red;
                PlayerStats.SkeletonScene = true;
                SceneManager.LoadScene("Town");
                break;

        }
    }
}
