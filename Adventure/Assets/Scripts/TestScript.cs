//script created by Declan Cullen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.material.color = Color.red;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
