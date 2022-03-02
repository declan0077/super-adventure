//script created by Declan Cullen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SkillpointDisplay : MonoBehaviour
{
    
    public TMP_Text Skillpointdisplay;
    public TMP_Text Strengthpointdisplay;
    public TMP_Text Agilitypointdisplay;
    public TMP_Text Constitutionpointdisplay;
    public TMP_Text Intelligencepointdisplay;
    public TMP_Text Charismapointdisplay;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
         int Skillpoint = PlayerStats.statupgrade;
        Skillpointdisplay.text = Skillpoint.ToString();
     
        Strengthpointdisplay.text = PlayerStats.Strength.ToString();
        Agilitypointdisplay.text = PlayerStats.Agility.ToString();
        Constitutionpointdisplay.text = PlayerStats.Constitution.ToString();
        Intelligencepointdisplay.text = PlayerStats.Intelligence.ToString();
        Charismapointdisplay.text = PlayerStats.Charisma.ToString();
    }
}
