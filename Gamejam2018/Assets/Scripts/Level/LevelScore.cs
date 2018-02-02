using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    private int currentScore;
    private int totalInfectable;
    private Text score;

    bool collectableMaster;

	void Start ()
    {
        score = GetComponent<Text>();
        currentScore = 0;
        collectableMaster = false;
	}
	void Update ()
    {
        string text = currentScore.ToString() + "/" + totalInfectable.ToString();
        score.text = text;

        if (currentScore == totalInfectable)
            collectableMaster = true;
	}

    public void IncrementScore(int amount)
    {
        currentScore += amount;
    }

    public void SetNumOfInfectable(int amount)
    {
        totalInfectable = amount;
    }

    public bool GetIsMaxScore()
    {
        return collectableMaster;
    }
}
