using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skills : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SCArrow"))
        {
            collision.gameObject.GetComponentInParent<Skillcheck>().onSuccessArea = true;
            Debug.Log("hit");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SCArrow"))
        {
            collision.gameObject.GetComponentInParent<Skillcheck>().onSuccessArea = false;
            Debug.Log("failed");
        }
    }
}