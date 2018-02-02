using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/FleeCheck")]
public class FleeCheckDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool stayFleeing = FleeCheck(controller);
        return stayFleeing;
    }

    private bool FleeCheck(StateController controller)
    {
        Vector3 enemyPos = controller.lastSeenEnemy.transform.position;
        Vector3 between = controller.transform.position - enemyPos;
        if (between.magnitude < controller.civStats.fleeDistance || controller.fleeTimer >= controller.civStats.fleeTime)
        {
            controller.fleeTimer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
