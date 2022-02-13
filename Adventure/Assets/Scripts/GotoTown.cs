using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GotoTown : MonoBehaviour
{
    // Start is called before the first frame update
  public void Town()
    {
        SceneManager.LoadScene("Town");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
