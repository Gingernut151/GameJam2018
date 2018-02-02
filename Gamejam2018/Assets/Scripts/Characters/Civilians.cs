using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilians : MonoBehaviour
{
    public CivilianStats civStats;
    public bool infected = false;
    private LevelScore score;

    public void Awake()
    {
        score = Object.FindObjectOfType<LevelScore>();
        EventManager.E_StandingInVomit += StandInVomit;
    }


    public void StandInVomit(GameObject civStood, PlayerEventArgs args)
    {
        if(args.tag == "Civilians" && args.civilian.infected == false)
        {
            score.IncrementScore(1);
            SoundManager.Instance.PlaySingleDistance(args.civilian.gameObject, "Infected1");
            Debug.Log("Stand in vomit called");
            args.civilian.infected = true;
            args.civilian.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
