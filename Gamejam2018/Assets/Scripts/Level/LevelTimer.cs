using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private Text matchTimer;
    [HideInInspector]
    public float matchTime;
    public float levelLength = 180;
    private bool pauseTimer;

    public bool timerExpired { private set; get; }

    //--------------------------------------------------------------------------------------------------
    void Start()
    {
        matchTimer = GetComponent<Text>();

        Time.timeScale = 1;
        timerExpired = false;
        matchTime = levelLength;
    }
    //--------------------------------------------------------------------------------------------------   
    void Update()
    {
        if (pauseTimer == false)
        {
            if (matchTime >= 0.0f)
            {
                MatchTimerCountdown();
            }
            else
            {
                timerExpired = true;
            }
        }

        UpdateTimeText();
    }
    //--------------------------------------------------------------------------------------------------
    void MatchTimerCountdown()
    {
        matchTime -= Time.deltaTime;
    }
    //--------------------------------------------------------------------------------------------------
    void UpdateTimeText()
    {
        int timeInSeconds = (int)matchTime;

        string minutes = Mathf.Floor(timeInSeconds / 60).ToString("00");
        string seconds = (timeInSeconds % 60).ToString("00");

        matchTimer.text = minutes + ":" + seconds;
    }
    //--------------------------------------------------------------------------------------------------
    public void ResetTimer()
    {
        matchTime = levelLength + 1.0f; // plus 1 because it keeps the time shown above the round length. Rounding down issue
        timerExpired = false;
    }
    public void PauseTimer(bool state)
    {
        pauseTimer = state;
    }

    public int GetTime()
    {
        return (int)matchTime;
    }
}