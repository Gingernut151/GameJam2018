using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Flee")]
public class FleeAction : Action
{

    public override void Act(StateController controller)
    {
        Flee(controller);
    }

    private void Flee(StateController controller)
    {

        // store the starting transform
        Transform startTransform = controller.transform;

        //temporarily point the object to look away from the player
        controller.transform.rotation = Quaternion.LookRotation(controller.transform.position - controller.lastSeenEnemy.transform.position);

        //Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
        // for this if you want variable results) and store it in a new Vector3 called runTo
        Vector3 runTo = controller.transform.position + controller.transform.forward * 5;
        //Debug.Log("runTo = " + runTo);

        //So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.

        NavMeshHit hit;    // stores the output in a variable called hit

        // 5 is the distance to check, assumes you use default for the NavMesh Layer name
        NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetAreaFromName("Walkable"));
        //Debug.Log("hit = " + hit + " hit.position = " + hit.position);

        // just used for testing - safe to ignore
        //nextTurnTime = Time.time + 5;

        // reset the transform back to our start transform
        controller.transform.position = startTransform.position;
        controller.transform.rotation = startTransform.rotation;

        // And get it to head towards the found NavMesh position
        controller.navMeshAgent.SetDestination(hit.position);

    }

    
}
