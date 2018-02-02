using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager> {

    //delegate
    public delegate void PlayerAttack(GameObject sender, PlayerEventArgs args);

    public delegate void EnemyAttack(GameObject sender, EnemyEventArgs args);
    //event
    public static event PlayerAttack E_StandingInVomit;

    public static event EnemyAttack E_CopAttack;

    public static void StandingInVomit(GameObject sender, PlayerEventArgs args)
    {
        if(E_StandingInVomit != null)
        {
            E_StandingInVomit(sender, args);
        }
    }
    public static void CopAttack(GameObject sender, EnemyEventArgs args)
    {
        if (E_CopAttack != null)
        {
            E_CopAttack(sender, args);
        }
    }
}




public class EventArgs
{
    public static readonly EventArgs Empty;

    public EventArgs() { }
}


public class PlayerEventArgs
{
    public Civilians civilian;
    public string tag;

    public PlayerEventArgs(Civilians civilian, string tag)
    {
        this.civilian = civilian;
        this.tag = tag;
    }

}

public class EnemyEventArgs
{
    public CopAttack cop;
    public string tag;

    public EnemyEventArgs(CopAttack cop, string tag)
    {
        this.cop = cop;
        this.tag = tag;
    }

}