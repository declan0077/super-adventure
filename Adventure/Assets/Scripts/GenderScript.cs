//script created by Declan Cullen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderScript : MonoBehaviour
{
    public GameObject DefaultBody;
    public GameObject Defaulthead;
    public GameObject DefaultLoin;
    public GameObject body;
    public GameObject head;
    public GameObject Loin;
    public Sprite Manbody;
    public Sprite Manhead;
    public Sprite ManLoin;
    public Sprite Femalebody;
    public Sprite Femalehead;
    public Sprite FemaleLoin;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerStats.Male == true)
        {
            body.GetComponent<SpriteRenderer>().sprite = Manbody;
            head.GetComponent<SpriteRenderer>().sprite = Manhead;
            Loin.GetComponent<SpriteRenderer>().sprite = ManLoin;
        }
        if (PlayerStats.Male == false)
        {
            DefaultBody.SetActive(false);
            Defaulthead.SetActive(false);
            DefaultLoin.SetActive(false);
            body.GetComponent<SpriteRenderer>().sprite = Femalebody;
            head.GetComponent<SpriteRenderer>().sprite = Femalehead;
            Loin.GetComponent<SpriteRenderer>().sprite = FemaleLoin;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
