using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour
{
    private StanimaBar stanima;
    public AttackValues attackValues;

    public Vomit vomit;
    public Bite bite;
    public Cough cough;
    public Slap slap;
    public Sneeze sneeze;

    private void Start()
    {
        stanima = Object.FindObjectOfType<StanimaBar>();
    }

    private void Update()
    {
        GetMouseClick();
    }

    private void GetMouseClick()
    {
        if (Input.GetMouseButtonUp(0)) // Left click
        {
            UsePower();
        }
        else if (Input.GetMouseButtonUp(1)) // Right click
        {

        }
        else if (Input.GetMouseButtonUp(2)) // Middle click
        {

        }
    }

    private void GetMouseScroll()
    {
        float scrollVal = Input.GetAxis("Mouse ScrollWheel");

        if (scrollVal > 0.0f) // Scroll up
        {

        }
        if (scrollVal < 0.0f) // Scroll down
        {

        }
    }
 
    private void UsePower()
    {
        AttackValue attack = attackValues.CurrentAttack;

        if (attack == AttackValue.Bite)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageBite))
            {
                stanima.ReduceStanima(attackValues.StanimaUsageBite);
                Instantiate(bite, transform.position, transform.rotation);
                Debug.Log("Bite Attack Occured");
            }
        }
        else if (attack == AttackValue.Cough)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageCough))
            {
                stanima.ReduceStanima(attackValues.StanimaUsageCough);
                Instantiate(cough, transform.position, transform.rotation);
                Debug.Log("Cough Attack Occured");
            }
        }
        else if (attack == AttackValue.Slap)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageSlap))
            {
                stanima.ReduceStanima(attackValues.StanimaUsageSlap);
                Instantiate(slap, transform.position, transform.rotation);
                Debug.Log("Slap Attack Occured");
            }
        }
        else if (attack == AttackValue.Sneeze)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageSneeze))
            {
                stanima.ReduceStanima(attackValues.StanimaUsageSneeze);
                Instantiate(sneeze, transform.position, transform.rotation);
                Debug.Log("Sneeze Attack Occured");
            }
        }
        else if (attack == AttackValue.Vomit)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageVomit))
            {
                SoundManager.Instance().PlaySingle("Vomit");
                stanima.ReduceStanima(attackValues.StanimaUsageVomit);
                Instantiate(vomit, transform.position, transform.rotation);
                Debug.Log("Vomit Attack Occured");
            }
        }
    }
}