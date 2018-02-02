using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StanimaBar : MonoBehaviour
{
    private int currentStanima;
    public int totalStanima = 100;
    public int restoreSpeed = 5;
    private float restoreAmount = 0.0f;
    private Slider stanimaBar;
    //--------------------------------------------------------------------------------------------------
    private void Start()
    {
        stanimaBar = GetComponent<Slider>();
        stanimaBar.maxValue = totalStanima;
        currentStanima = totalStanima;
    }
    //--------------------------------------------------------------------------------------------------
    void Update()
    {
        stanimaBar.value = currentStanima;

        if (currentStanima < totalStanima)
        {
            restoreAmount += (restoreSpeed * Time.deltaTime);

            if (restoreAmount >= 1.0f)
            {
                currentStanima += 1;
                restoreAmount = 0.0f;
            }
        }
    }
    //--------------------------------------------------------------------------------------------------
    public void RestoreStanima(int amount)
    {
        currentStanima += amount;
    }
    //--------------------------------------------------------------------------------------------------
    public void ReduceStanima(int amount)
    {
        currentStanima -= amount;
    }
    public bool IsThereEnough(int amount)
    {
        if (currentStanima - amount >= 0.0f)
        {
            return true;
        }

        return false;
    }
}