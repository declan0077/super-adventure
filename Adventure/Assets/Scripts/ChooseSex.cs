using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChooseSex : MonoBehaviour, IPointerClickHandler
{
    public bool isMale = false;

  

    public GameObject maleFaceBorder;
    public GameObject femaleFaceBorder;

    public AudioSource clickSound;

    public Button confirmButton;





    // Start is called before the first frame update
    void Start()
    {
      
    }


    void Update()
    {
       
    }

    // Update is called once per frame

    public void OnPointerClick(PointerEventData pointerEventData)
    {
       //Activates the Border around the chosen Sex face, removes border from other if applied.
        clickSound.Play();
        //Checks which Img the Player Clicks on, and changes isMale bool from results
        if(pointerEventData.pointerCurrentRaycast.gameObject.name == "MaleImg")
        {
            isMale = true;
            maleFaceBorder.SetActive(true);
            femaleFaceBorder.SetActive(false);
            confirmButton.enabled = true;
            PlayerStats.Male = true;
        }
        else
        {
            isMale = false;
            femaleFaceBorder.SetActive(true);
            maleFaceBorder.SetActive(false);
            confirmButton.enabled = true;
            PlayerStats.Male = false;
        }

        Debug.Log(isMale);
       
    }

}
