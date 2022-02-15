using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button myButton;

    public Sprite oldSprite;
    public Sprite newSprite;

    public AudioSource hoverSound;

    // Start is called before the first frame update
    void Start()
    {
       
        myButton = GetComponent<Button>();
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myButton.image.sprite = newSprite; 
        Debug.Log("Mouse Enter");
        hoverSound.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse Exit");
        myButton.image.sprite = oldSprite; 
    }
}
