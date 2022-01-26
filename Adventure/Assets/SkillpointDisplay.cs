using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SkillpointDisplay : MonoBehaviour
{
   public TMP_Text Skillpointdisplay;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
         int Skillpoint = PlayerStats.statupgrade;
        Skillpointdisplay.text = Skillpoint.ToString();
    }
}
