using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomit : MonoBehaviour
{
    private int stanimaUsage;
    private float strength;
    public float durationLength = 50.0f;
    private float durationAmount;

    private void Start()
    {
        stanimaUsage = 20;
        strength = 5.0f;
        durationAmount = durationLength;
        SoundManager.Instance().PlaySingle("Vomit");
    }

    private void Update()
    {
        durationAmount -= Time.deltaTime;

        if (durationAmount <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding with vomit");
        EventManager.StandingInVomit(gameObject, new PlayerEventArgs(other.gameObject.GetComponent<Civilians>(), other.gameObject.tag));
    }

}
