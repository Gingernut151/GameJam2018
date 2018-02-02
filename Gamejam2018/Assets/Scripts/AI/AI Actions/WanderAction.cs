using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : Action
{
    
    public override void Act(StateController controller)
    {
        Wander(controller);
    }

    private void Wander(StateController controller)
    {

        controller.navMeshAgent.isStopped = false;
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending || controller.wanderTimer >= controller.civStats.wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(controller.transform.position, controller.civStats.wanderRadius, -1);
            controller.navMeshAgent.SetDestination(newPos);
            controller.wanderTimer = 0;
        }
            
        
        
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
