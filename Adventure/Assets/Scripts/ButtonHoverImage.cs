using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //UI
    private Button myButton;

    //Sprites
    public Sprite oldSprite;
    public Sprite newSprite;

    //Audio
    public AudioSource hoverSound;

    void Start()
    {
        myButton = GetComponent<Button>();
    }
       

    public void OnPointerEnter(PointerEventData eventData)
    {
        myButton.image.sprite = newSprite; 
        hoverSound.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
        myButton.image.sprite = oldSprite; 
    }
}
