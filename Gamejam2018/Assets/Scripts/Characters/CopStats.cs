using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Cop Stats")]
public class CopStats : ScriptableObject
{

    public float resistance = 0.8f;
    public Vector3 spawnPos = new Vector3(0, 0, 0);
    public float sightRange = 10f;
    public float lookSphereRadius = 5f;
    public string tagName = "Player"; //what the cops are looking for
}
