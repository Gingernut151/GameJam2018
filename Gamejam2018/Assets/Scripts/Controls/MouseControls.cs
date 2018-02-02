using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour
{
    private Animator attackImage;
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
        attackImage = UnityEngine.GameObject.FindGameObjectWithTag("Attack_Image").GetComponent<Animator>();
    }

    private void Update()
    {
        GetMouseClick();
        GetMouseScroll();
        SwitchPower();
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

        if (scrollVal < 0.0f) // Scroll down
        {
            if ((int)(attackValues.CurrentAttack + 1) <= attackValues.numOfAttacks - 1)
            {
                attackValues.CurrentAttack++;
            }
            else
            {
                attackValues.CurrentAttack = 0;
            }

            Debug.Log("New weapon: " + attackValues.CurrentAttack.ToString());
        }
        else if (scrollVal > 0.0f)
        {
            if ( (int)(attackValues.CurrentAttack - 1) >= 0)
            {
                attackValues.CurrentAttack -= 1;
            }
            else
            {
                attackValues.CurrentAttack = (AttackValue)(attackValues.numOfAttacks - 1);
            }

            Debug.Log("New weapon: " + attackValues.CurrentAttack.ToString());
        }          
    }
 
    private void UsePower()
    {
        AttackValue attack = attackValues.CurrentAttack;

        if (attack == AttackValue.Bite)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageBite))
            {
                SoundManager.Instance.PlaySingle("Bite1");
                stanima.ReduceStanima(attackValues.StanimaUsageBite);
                Instantiate(bite, transform.position, transform.rotation);
                Debug.Log("Bite Attack Occured");
            }
        }
        else if (attack == AttackValue.Cough)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageCough))
            {
                SoundManager.Instance.PlaySingle("Cough1");
                stanima.ReduceStanima(attackValues.StanimaUsageCough);
                Instantiate(cough, transform.position, transform.rotation);
                Debug.Log("Cough Attack Occured");
            }
        }
        else if (attack == AttackValue.Slap)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageSlap))
            {
                SoundManager.Instance.PlaySingle("Slap1");
                stanima.ReduceStanima(attackValues.StanimaUsageSlap);
                Instantiate(slap, transform.position, transform.rotation);
                Debug.Log("Slap Attack Occured");
            }
        }
        else if (attack == AttackValue.Sneeze)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageSneeze))
            {
                SoundManager.Instance.PlaySingle("Sneeze1");
                stanima.ReduceStanima(attackValues.StanimaUsageSneeze);
                Instantiate(sneeze, transform.position, transform.rotation);
                Debug.Log("Sneeze Attack Occured");
            }
        }
        else if (attack == AttackValue.Vomit)
        {
            if (stanima.IsThereEnough(attackValues.StanimaUsageVomit))
            {
                SoundManager.Instance.PlaySingle("Vomit1");
                stanima.ReduceStanima(attackValues.StanimaUsageVomit);
                Instantiate(vomit, transform.position, transform.rotation);
                Debug.Log("Vomit Attack Occured");
            }
        }
    }

    private void SwitchPower()
    {
        if (attackValues.CurrentAttack == AttackValue.Bite)
        {
            attackImage.SetBool("Bite", true);
            attackImage.SetBool("Cough", false);
            attackImage.SetBool("Sneeze", false);
            attackImage.SetBool("Slap", false);
            attackImage.SetBool("Vomit", false);
        }
        else if (attackValues.CurrentAttack == AttackValue.Cough)
        {
            attackImage.SetBool("Bite", false);
            attackImage.SetBool("Cough", true);
            attackImage.SetBool("Sneeze", false);
            attackImage.SetBool("Slap", false);
            attackImage.SetBool("Vomit", false);
        }
        else if (attackValues.CurrentAttack == AttackValue.Sneeze)
        {
            attackImage.SetBool("Bite", false);
            attackImage.SetBool("Cough", false);
            attackImage.SetBool("Sneeze", true);
            attackImage.SetBool("Slap", false);
            attackImage.SetBool("Vomit", false);
        }
        else if (attackValues.CurrentAttack == AttackValue.Slap)
        {
            attackImage.SetBool("Bite", false);
            attackImage.SetBool("Cough", false);
            attackImage.SetBool("Sneeze", false);
            attackImage.SetBool("Slap", true);
            attackImage.SetBool("Vomit", false);
        }
        else if (attackValues.CurrentAttack == AttackValue.Vomit)
        {
            attackImage.SetBool("Bite", false);
            attackImage.SetBool("Cough", false);
            attackImage.SetBool("Sneeze", false);
            attackImage.SetBool("Slap", false);
            attackImage.SetBool("Vomit", true);
        }
    }
}