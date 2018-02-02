using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour
{

    public State currentState;
    public Transform eyes;
    public State remainState;
    public CivilianStats civStats;
    public CopStats copStats;
    public GameObject lastSeenEnemy;
    public float fleeTimer;
    public float wanderTimer;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;


    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetupAI(bool aiActivationFromManager)
    {
        
        aiActive = aiActivationFromManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    public void SetupAI(bool aiActivationFromManager, List<Transform> waypointsFromManager)
    {
        wayPointList = waypointsFromManager;
        aiActive = aiActivationFromManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    void Update()
    {
        if (!aiActive)
            return;
        if (civStats != null)
        {
            wanderTimer += Time.deltaTime;
            fleeTimer += Time.deltaTime;
        }
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            if (civStats != null)
            {
                Gizmos.DrawWireSphere(eyes.position, civStats.sightRange);
            }
            else
            {
                Gizmos.DrawWireSphere(eyes.position, copStats.sightRange);
            }
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}