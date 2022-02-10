using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TalkingScript : MonoBehaviour
{
    public int TextNumber;
    public Sprite King;
    public Sprite Princess;
    public Sprite Goblin;
    public Sprite Skeleton;
    public Sprite Orge;
    public Sprite Player;
    public TMP_Text Text;
    public TMP_Text Name;
    public Image uichar;
    // Start is called before the first frame update
    public void Textupdate()
    {
        TextNumber += 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch(TextNumber)
        {
            case 0:
                uichar.GetComponent<Image>().sprite = Player;
                Name.text = ("Player:");
                Text.text = ("Damm, Spell caster making me lose my hair");
                break;
            case 1:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("*Walks into the room*");
                break;
            case 2:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("You there Player, you have been a trusty servant for many years. I have a task for you");
                break;
            case 3:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = (".... M-My Daughter has been missing for some time");
                break;
            case 4:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("Last reports said she was in the forest, my knights have been searching but.... no luck");
                break;
            case 5:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("...");
                break;
            case 6:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("Well Get going this plot will not finish itself");
                break;
            case 7:
                uichar.GetComponent<Image>().sprite = Player;
                Name.text = ("Player:");
                Text.text = ("Yes M'lord");
           
                break;
            case 8:
                uichar.GetComponent<Image>().sprite = Player;
                Name.text = ("Player:");
                Text.text = ("Yes M'lord");
                SceneManager.LoadScene("Town");
                break;
        }
    }
}
