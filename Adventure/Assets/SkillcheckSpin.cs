using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillcheckSpin : MonoBehaviour
{
    public bool onSuccessArea;
    public bool flipflop;
    public float speed = 10f;
    public Player playerScript;
    public Enemy enemyScript;
    public GameObject blockSkillcheck;
     void Start()
    {
     
    }
    // Update is called once per frame
    void Update()
    {
       
        if (flipflop) transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        else transform.Rotate(new Vector3(0, 0, -1 * (speed * Time.deltaTime)));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onSuccessArea)
            {
                playerScript.blockActive = true;
                StopCoroutine(FalseYap());
                StartCoroutine(FalseYap());
            }
            else
            {
                playerScript.blockActive = false;
                enemyScript.Blockdamage();
                StopCoroutine(FalseYap());
                StartCoroutine(FalseYap());

            }
            flipflop = !flipflop;
        }

       
  
    }
    public void stop()
    {
        StartCoroutine(Stop());
    }
   public IEnumerator Stop()
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        new WaitForSeconds(1);
        enemyScript.enemyChosenMove = true;
        playerScript.playerChosenMove = false;
        enemyScript.Blockdamage();
        blockSkillcheck.SetActive(false);

    }
    private IEnumerator FalseYap()
    {
        yield return new WaitForSeconds(0.1f);
        enemyScript.enemyChosenMove = true;
        playerScript.playerChosenMove = false;
        blockSkillcheck.SetActive(false);
        playerScript.blockActive = false;
    }
}
