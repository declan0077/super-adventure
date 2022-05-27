using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimPreview : MonoBehaviour
{
    //Name of the Animations that can be in the preview Randomization
    public string[] randomAnimationSelection;


    //Animator controlling the the randomization
    public Animator playerPreviewAnimations;

    // Start is called before the first frame update
    void Start()
    {
        playerPreviewAnimations.Play("PlayerCharacter");
        StartCoroutine(AnimationPreview());
    }



    IEnumerator AnimationPreview(){
        while (true){
             yield return new WaitForSeconds(5);
            //Random Int generator
            int rand = Random.Range(0, randomAnimationSelection.Length);
            //Chooses a random animation (String) from the array
            string chosenAnimation = randomAnimationSelection[rand];
            //Plays the random animation
            playerPreviewAnimations.Play(chosenAnimation);
            yield return new WaitForSeconds(2);
            //Resets the animation back to Idle once complete
            playerPreviewAnimations.Play("PlayerCharacter");
        }
    }
}
