using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeButton : MonoBehaviour
{
    // Start is called before the first frame update
  public void Home()
    {
        SceneManager.LoadScene("Town");
    }
}
