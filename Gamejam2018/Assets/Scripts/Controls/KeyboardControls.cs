using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardControls : MonoBehaviour
{
    private Animator attackImage;
    public AttackValues attackValues;

    private void Start()
    {
        attackImage = UnityEngine.GameObject.FindGameObjectWithTag("Attack_Image").GetComponent<Animator>();
    }
    void Update()
    {
        Actions();
        Powers();
    }

       private void Actions()
    {
        if (Input.GetKeyUp(KeyCode.E)) // Interact
            Interact();
        else if (Input.GetKey(KeyCode.Tab)) // Map
            DisplayMap();
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("You have pressed Main Menu Button");
            Initiate.Fade("MainMenu", Color.black, 1.5f);
        }
    }
    private void Powers()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)) // Bite
            SwitchPower(AttackValue.Bite);
        else if (Input.GetKeyUp(KeyCode.Alpha2)) // Cough
            SwitchPower(AttackValue.Cough);
        else if (Input.GetKeyUp(KeyCode.Alpha3)) // Slap
            SwitchPower(AttackValue.Slap);
        else if (Input.GetKeyUp(KeyCode.Alpha4)) // Sneeze
            SwitchPower(AttackValue.Sneeze);
        else if (Input.GetKeyUp(KeyCode.Alpha5)) // Vomit
            SwitchPower(AttackValue.Vomit);
    }

    private void Interact ()
    {

    }

    private void DisplayMap()
    {

    }

    private void SwitchPower(AttackValue attack)
    {
        attackValues.CurrentAttack = attack;

        if (attack == AttackValue.Bite)
        {
            attackImage.SetBool("Bite", true);
            attackImage.SetBool("Cough", false);
            attackImage.SetBool("Sneeze", false);
            attackImage.SetBool("Slap", false);
            attackImage.SetBool("Vomit", false);
        }
        else if (attack == AttackValue.Cough)
        {
            attackImage.SetBool("Bite", false);
            attackImage.SetBool("Cough", true);
            attackImage.SetBool("Sneeze", false);
            attackImage.SetBool("Slap", false);
            attackImage.SetBool("Vomit", false);
        }
        else if (attack == AttackValue.Sneeze)
        {
            attackImage.SetBool("Bite", false);
            attackImage.SetBool("Cough", false);
            attackImage.SetBool("Sneeze", true);
            attackImage.SetBool("Slap", false);
            attackImage.SetBool("Vomit", false);
        }
        else if (attack == AttackValue.Slap)
        {
            attackImage.SetBool("Bite", false);
            attackImage.SetBool("Cough", false);
            attackImage.SetBool("Sneeze", false);
            attackImage.SetBool("Slap", true);
            attackImage.SetBool("Vomit", false);
        }
        else if (attack == AttackValue.Vomit)
        {
            attackImage.SetBool("Bite", false);
            attackImage.SetBool("Cough", false);
            attackImage.SetBool("Sneeze", false);
            attackImage.SetBool("Slap", false);
            attackImage.SetBool("Vomit", true);
        }
    }
}
