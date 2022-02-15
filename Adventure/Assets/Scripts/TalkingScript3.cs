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
    public Sprite scroll;
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
                uichar.GetComponent<Image>().sprite = Skeleton;
                Name.text = ("Skeleton:");
                Text.text = ("kha kha kha");
                break;
            case 1:
                uichar.GetComponent<Image>().sprite = Player;
                Name.text = ("Player:");
                Text.text = ("*Bonk!* Hits skeleton!");
                break;
            case 2:
                uichar.GetComponent<Image>().sprite = Skeleton;
                Name.text = ("Crumbling skeleton:");
                Text.text = ("*Crumbles*");
                break;
            case 3:
                uichar.GetComponent<Image>().sprite = Player;
                Name.text = ("Player:");
                Text.text = ("There is no sign of the princess here, where could she of gone");
                break;
            case 4:
                uichar.GetComponent<Image>().sprite = Player;
                Name.text = ("Player:");
                Text.text = ("Whats that over there?! Is that a scroll");
                break;
            case 5:
                uichar.GetComponent<Image>().sprite = scroll;
                Name.text = ("scroll:");
                Text.text = ("By order of Ed the overlord, Take her to the castle");
                Text.color = Color.red;
                
                PlayerStats.SkeletonScene = true;
                break;
            case 6:
                uichar.GetComponent<Image>().sprite = scroll;
                Name.text = ("scroll:");
                Text.text = ("By order of Ed the overlord , Take her to the castle");
                Text.color = Color.red;

                SceneManager.LoadScene("Town");
                break;

        }
    }
}