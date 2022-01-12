using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class textFade : MonoBehaviour
{

    public TMP_Text damageDone;


    public float fadeTime;
    public bool fadingIn;

    // Start is called before the first frame update
    void Start()
    {
        damageDone.CrossFadeAlpha(0, 0.0f, false);
        fadeTime = 0;
        fadingIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            FadeIn();
        }else if(damageDone.color.a != 0)
        {
            damageDone.CrossFadeAlpha(0, 0.5f, false);
        }
    }

    void FadeIn()
    {
        damageDone.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if (damageDone.color.a == 1 && fadeTime > 1.5f)
        {
            fadingIn = false;
            fadeTime = 0;
        }
    }
}
