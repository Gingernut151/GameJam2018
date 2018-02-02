using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int currentHealth;
    private int totalHealth = 100;
    private Slider healthBar;
    //--------------------------------------------------------------------------------------------------
    private void Start()
    {
        EventManager.E_CopAttack += TakeDamage;
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = totalHealth;
        currentHealth = totalHealth;

    }
    //--------------------------------------------------------------------------------------------------
    void Update()
    {
        healthBar.value = currentHealth;
    }
    //--------------------------------------------------------------------------------------------------
    public void RestoreHealth(int amount)
    {
        currentHealth += amount;
    }
    //--------------------------------------------------------------------------------------------------
    public void ReduceHealth(int amount)
    {
        currentHealth -= amount;
    }
    //--------------------------------------------------------------------------------------------------
    public void TakeDamage(GameObject gameObject, EnemyEventArgs args)
    {
        if (args.tag == "Player")
        {
            currentHealth -= 10;
        }
    }
    //--------------------------------------------------------------------------------------------------
    public int GetHealth()
    {
        return currentHealth;
    }
}