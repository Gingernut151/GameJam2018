using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomit : MonoBehaviour
{
    public float durationLength = 50.0f;
    private float durationAmount;

    private void Start()
    {
        durationAmount = durationLength;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        transform.Translate(Vector3.up);
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
