using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GameOverLogic : MonoBehaviour
{
    Image winner;
    Image looser;

    private void Start()
    {
        winner = UnityEngine.GameObject.FindGameObjectWithTag("Winner").GetComponent<Image>();
        looser = UnityEngine.GameObject.FindGameObjectWithTag("Looser").GetComponent<Image>();

        if (GameOverData.isWinner == true)
        {
            winner.enabled = true;
            looser.enabled = false;
        }
        else
        {
            winner.enabled = false;
            looser.enabled = true;
        }
    }
}
