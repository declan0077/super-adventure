//script created by Declan Cullen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlipFace : MonoBehaviour
{
    public GameObject Malefaceicon;
    public GameObject Femalefaceicon;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerStats.Male == true)
        {
            Malefaceicon.SetActive(true);
            Femalefaceicon.SetActive(false);
        }
        else
        {
            Malefaceicon.SetActive(false);
            Femalefaceicon.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
