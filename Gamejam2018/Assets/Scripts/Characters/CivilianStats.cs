using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Civilian Stats")]
public class CivilianStats : ScriptableObject {

    public float resistance = 0.5f;
    public Vector3 spawnPos = new Vector3(0,0,0);
    public float sightRange = 10f;
    public float lookSphereRadius = 5f;
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;
    public float fleeDistance = 30f;
    public float fleeTime = 2f;
    public string tagName = "Player"; // what the civs are looking for
}
