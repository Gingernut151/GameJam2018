using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopAttack : MonoBehaviour {
    public float attackTimer = 2f;
    public float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        if (timer >= attackTimer)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                EventManager.CopAttack(gameObject, new EnemyEventArgs(other.gameObject.GetComponent<CopAttack>(), other.gameObject.tag));
                timer = 0f;
            }
        }
    }
}
