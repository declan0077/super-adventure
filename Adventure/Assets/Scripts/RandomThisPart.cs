//script created by Declan Cullen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomThisPart : MonoBehaviour
{
    public Sprite part;
    public Sprite part2;
    public Sprite part3;
    void Start()
    {
        if (Random.value < 0.5f)
        {
            if (Random.value < 0.5f)
            {
                GetComponent<SpriteRenderer>().sprite = part3;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = part;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = part2;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
