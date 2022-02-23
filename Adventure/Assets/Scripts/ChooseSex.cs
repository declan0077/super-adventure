//Script Created and Owned by Dane Donaldson

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChooseSex : MonoBehaviour, IPointerClickHandler
{


    //Bools
    public bool isMale = false;

  
    //GameObjects
    public GameObject maleFaceBorder;
    public GameObject femaleFaceBorder;

    //Audio
    public AudioSource clickSound;
    public AudioSource maleGreeting;
    public AudioSource femaleGreeting;

    //UI
    public Button confirmButton;



    public void OnPointerClick(PointerEventData pointerEventData)
    {
       //Activates the Border around the chosen Sex face, removes border from other if applied.
        
        //Checks which Img the Player Clicks on, and changes isMale bool from results
        if(pointerEventData.pointerCurrentRaycast.gameObject.name == "MaleImg")
        {
            clickSound.Play();
            isMale = true;
            maleFaceBorder.SetActive(true);
            femaleFaceBorder.SetActive(false);
            confirmButton.enabled = true;
            PlayerStats.Male = true;
            maleGreeting.Play();
            femaleGreeting.Stop();
        }
        else if(pointerEventData.pointerCurrentRaycast.gameObject.name == "FemaleImg")
        {
            clickSound.Play();
            isMale = false;
            femaleFaceBorder.SetActive(true);
            maleFaceBorder.SetActive(false);
            confirmButton.enabled = true;
            PlayerStats.Male = false;
            femaleGreeting.Play();
            maleGreeting.Stop();

        }

        Debug.Log(isMale);
       
    }

}
