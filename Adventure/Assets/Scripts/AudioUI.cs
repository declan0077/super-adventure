using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUI : MonoBehaviour
{
    public AudioSource[] uiClickSound;

    public int randSelection;


    // Start is called before the first frame update
    void Start()
    {
        randSelection = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIClickSoundPlay()
    {
        uiClickSound[randSelection].Play();
    }
}
