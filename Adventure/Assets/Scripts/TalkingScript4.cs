using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TalkingScript4 : MonoBehaviour
{
    public int TextNumber;
    public Sprite Princess;
    public Sprite Player;
    public Sprite FemalePlayer;
    public Sprite Boss;
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
                Text.text = ("Oh hero you have to save me!");
                break;
            case 1:
                uichar.GetComponent<Image>().sprite = Boss;
                Name.text = ("Boss:");
                Text.text = ("Hahahaha Silly human you cant beat me");
                break;
            case 2:
                 if (PlayerStats.Male == true)
                {
                    uichar.GetComponent<Image>().sprite = Player;
                }
                else
                {
                    uichar.GetComponent<Image>().sprite = FemalePlayer;
                }
                Name.text = (playerName + ": ");
                Text.text = ("Fear not for I AM HERE ");
                Text.fontSize = 50;
                break;
            case 3:
                uichar.GetComponent<Image>().sprite = Boss;
                Name.text = ("Boss:");
                Text.text = ("Let us fight!");
                Text.fontSize = 36;
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
                Name.text = ("Player:");
                Text.text = ("Lets go");
                PlayerStats.BigEdScene = true;
                SceneManager.LoadScene("Castle");
                break;
          


        }
    }
}
