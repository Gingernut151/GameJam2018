using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AttackValues")]
public class AttackValues : ScriptableObject
{
    [Space]
    [Header("Stanima Usage")]
    public int StanimaUsageVomit = 20;
    public int StanimaUsageBite = 10;
    public int StanimaUsageSlap = 10;
    public int StanimaUsageSneeze = 40;
    public int StanimaUsageCough = 50;

    [Space]
    [Header("General")]
    public AttackValue CurrentAttack = AttackValue.Bite;
    public int numOfAttacks = 5;
    public int Stanima;
}