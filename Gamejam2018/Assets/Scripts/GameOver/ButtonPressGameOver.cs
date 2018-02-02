using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressGameOver : MonoBehaviour
{
    public string scene;
    public Color loadToColor = Color.black;
    public float fadeTime = 1.5f;
    //--------------------------------------------------------------------------------------------------
    public void MainMenuButtonPressed()
    {
        Debug.Log("You have pressed Main Menu Button");
        Initiate.Fade(scene, loadToColor, fadeTime);
    }
}
