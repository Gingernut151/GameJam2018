using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ChaseCheck")]
public class ChaseCheckDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool endChasing = ChaseCheck(controller);
        return endChasing;
    }

    private bool ChaseCheck(StateController controller)
    {
        Vector3 enemyPos = controller.lastSeenEnemy.transform.position;
        Vector3 between = controller.transform.position - enemyPos;
        if (between.magnitude > 20f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}