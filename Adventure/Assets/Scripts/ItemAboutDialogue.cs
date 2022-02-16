using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemAboutDialogue : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //UI
    private Image itemForDialogue;

    public GameObject itemDialogue;

    //Audio
    public AudioSource hoverSound;

    void Start()
    {
        itemForDialogue = GetComponent<Image>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //Sets the items dialogue active when Player hovers over
        itemDialogue.SetActive(true);
        hoverSound.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        itemDialogue.SetActive(false);
    }
}
