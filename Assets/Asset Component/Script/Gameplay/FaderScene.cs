using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaderScene : MonoBehaviour
{
    private string sceneToLoad;
    private Image theImage;
    public float transitionSpeed;
    private bool isDisplay;

    #region MonoBehaviour Callbacks

    private void Start()
    {
        theImage = GetComponent<Image>();
        isDisplay = true;
    }
    
    private void Update()
    {
        if(isDisplay){
            theImage.material.SetFloat("_CutOff", Mathf.MoveTowards(theImage.material.GetFloat("_CutOff"), 1.1f, transitionSpeed * Time.unscaledDeltaTime));
        }
        else {
            theImage.material.SetFloat("_CutOff", Mathf.MoveTowards(theImage.material.GetFloat("_CutOff"), -0.1f - theImage.material.GetFloat("_Smoothing"), transitionSpeed * Time.unscaledDeltaTime));

            if(theImage.material.GetFloat("_CutOff") == -0.1f - theImage.material.GetFloat("_Smoothing")){
                SceneManager.LoadScene(sceneToLoad);
            }
        }

    }

    #endregion
   

    public void SceneLoad(string sceneName)
    {
        sceneToLoad = sceneName;
        isDisplay = false;
    }
}
