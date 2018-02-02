using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LevelOverConditions : MonoBehaviour
{
    HealthBar health;
    LevelTimer timer;
    LevelScore score;

    private void Start()
    {
        health = Object.FindObjectOfType<HealthBar>();
        timer = Object.FindObjectOfType<LevelTimer>();
        score = Object.FindObjectOfType<LevelScore>();
    }

    private void Update()
    {
        if ((health.GetHealth() <= 0) || (timer.GetTime() <= 0))
        {
            Debug.Log("You Loose");
            GameOverData.isWinner = false;
            Initiate.Fade("GameOver", Color.black, 1.5f);
        }
        else if (score.GetIsMaxScore() == true)
        {
            Debug.Log("You Win");
            GameOverData.isWinner = true;
            Initiate.Fade("GameOver", Color.black, 1.5f);
        }
    }
}
