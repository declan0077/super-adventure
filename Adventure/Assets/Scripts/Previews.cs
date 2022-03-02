//Script created by Dane Donaldson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Previews : MonoBehaviour
{
    public GameObject pushPreview;
    public GameObject meleePreview;
    public GameObject rangedPreview;
    public GameObject blockPreview;
    public GameObject movePreview;

    public GameObject previewBorder;
    public GameObject abilityDescription;
    public GameObject previewDescription;
    public GameObject previewSelections;

    public TMP_Text tutorialTitle;

    public GameObject returnButton;
    
    // Start is called before the first frame update


    public void PushPreview()
    {
        previewBorder.SetActive(true);
        pushPreview.SetActive(true);
        meleePreview.SetActive(false);
        rangedPreview.SetActive(false);
        blockPreview.SetActive(false);
        movePreview.SetActive(false);
        abilityDescription.SetActive(false);
        previewDescription.SetActive(false);
        tutorialTitle.text = ("Preview");
        returnButton.SetActive(true);
        previewSelections.SetActive(true);
    }
    public void MeleePreview()
    {
        //Melee only works when it's set to false, before being set to true again. Not sure why
        previewBorder.SetActive(true);
        meleePreview.SetActive(false);
        pushPreview.SetActive(false);
        rangedPreview.SetActive(false);
        blockPreview.SetActive(false);
        movePreview.SetActive(false);
        abilityDescription.SetActive(false);
        previewDescription.SetActive(false);
        tutorialTitle.text = ("Preview");
        returnButton.SetActive(true);
        previewSelections.SetActive(true);
        meleePreview.SetActive(true);
    }
    public void RangedPreview()
    {
        previewBorder.SetActive(true);
        pushPreview.SetActive(false);
        meleePreview.SetActive(false);
        rangedPreview.SetActive(true);
        blockPreview.SetActive(false);
        movePreview.SetActive(false);
        abilityDescription.SetActive(false);
        previewDescription.SetActive(false);
        tutorialTitle.text = ("Preview");
        returnButton.SetActive(true);
        previewSelections.SetActive(true);
    }

    public void BlockPreview()
    {
        previewBorder.SetActive(true);
        pushPreview.SetActive(false);
        meleePreview.SetActive(false);
        rangedPreview.SetActive(false);
        blockPreview.SetActive(true);
        movePreview.SetActive(false);
        abilityDescription.SetActive(false);
        previewDescription.SetActive(false);
        tutorialTitle.text = ("Preview");
        returnButton.SetActive(true);
        previewSelections.SetActive(true);
    }

    public void MovePreview()
    {
        previewBorder.SetActive(true);
        pushPreview.SetActive(false);
        meleePreview.SetActive(false);
        rangedPreview.SetActive(false);
        blockPreview.SetActive(false);
        movePreview.SetActive(true);
        abilityDescription.SetActive(false);
        previewDescription.SetActive(false);
        tutorialTitle.text = ("Preview");
        returnButton.SetActive(true);
        previewSelections.SetActive(true);
    }


    public void LeavePreview()
    {
        abilityDescription.SetActive(true);
        previewDescription.SetActive(true);
        tutorialTitle.text = ("Ability Guide");
        previewBorder.SetActive(false);
        pushPreview.SetActive(false);
        meleePreview.SetActive(false);
        rangedPreview.SetActive(false);
        blockPreview.SetActive(false);
        movePreview.SetActive(false);
        returnButton.SetActive(false);
        previewSelections.SetActive(false);
    }



}
