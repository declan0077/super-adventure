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
                Text.text = ("*Enters Room*");
                break;
            case 2:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("You there! Player...  You have been a trusty servant for many years. I have a task for you");
                break;
            case 3:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = (".... M-My Daughter has been missing for quite some time");
                break;
            case 4:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("Last reports say she was in the forest, my Knights have been searching to no avail.");
                break;
            case 5:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("...");
                break;
            case 6:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("Do you know how to fight?");
                break;
            case 7:
                uichar.GetComponent<Image>().sprite = Player;
                Name.text = ("Player:");
                Text.text = ("Yes M'lord");
           
                break;
            case 8:
                uichar.GetComponent<Image>().sprite = King;
                Name.text = ("King:");
                Text.text = ("Well to test your mettle and to knight you, go into the Western forest and fight the legendary Ricky");
                SceneManager.LoadScene("Town");
                break;
        }
    }
}
