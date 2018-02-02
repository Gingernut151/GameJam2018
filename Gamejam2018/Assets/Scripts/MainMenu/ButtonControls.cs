using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControls : MonoBehaviour
{
    public string scene;
    public Color loadToColor = Color.black;
    public float fadeTime = 1.5f;

    //--------------------------------------------------------------------------------------------------
    public void ExitButtonPressed()
    {
        Debug.Log("You have pressed Close");
        Application.Quit();
    }
    //--------------------------------------------------------------------------------------------------
    public void MallButtonPressed()
    {
        Debug.Log("You have pressed Mall Button");
        Initiate.Fade(scene, loadToColor, fadeTime);
    }
    //--------------------------------------------------------------------------------------------------
    public void SettingsButtonPressed()
    {
        Debug.Log("You have pressed Settings Button");
        Initiate.Fade(scene, loadToColor, fadeTime);
    }
}
