using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TalkingScript5 : MonoBehaviour
{
    public int TextNumber;
    public Sprite Princess;
    public Sprite Player;
    public Sprite FemalePlayer;
    public Sprite Boss;
    public Sprite Narrator;
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
                uichar.GetComponent<Image>().sprite = Princess;
                Name.text = ("Princess:");
                Text.text = (playerName + "! Is that really you? I never thought you'd be the one to rescue me.");
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
                Name.text = (playerName +": ");
                Text.text = ("Your Father sent me, I couldn't refuse when I knew you were taken. I'm glad you're unharmed");
                break;

            case 2:
                uichar.GetComponent<Image>().sprite = Princess;
                Name.text = ("Princess:");
                Text.text = ("My Hero! ... But wait, don't we have to travel all the way back, what if the Monsters you slain come back?");
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
                Text.text = ("It's a good thing I know how to C Sharp, Princess");
                break;
            case 4:
                uichar.GetComponent<Image>().sprite = Narrator;
                Name.text = ("Narrator:");
                Text.text = ("The End");
                break;
            case 5:
                uichar.GetComponent<Image>().sprite = Narrator;
                Name.text = ("Narrator:");
                Text.text = ("The End");
                Application.Quit();
                break;


        }
    }
}
