using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    string tagName;
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;
        
        if (controller.civStats != null)
        {
            tagName = controller.civStats.tagName;
        }
        if (controller.copStats != null)
        {
            tagName = controller.copStats.tagName;
        }

        if (controller.civStats != null)
        {
            Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.civStats.sightRange, Color.green);
            if (Physics.SphereCast(controller.eyes.position, controller.civStats.lookSphereRadius, controller.eyes.forward, out hit, controller.civStats.sightRange)
            && hit.collider.CompareTag(tagName))
            {
                controller.lastSeenEnemy = hit.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }

        if (controller.copStats != null)
        {
            Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.copStats.sightRange, Color.green);

            if (Physics.SphereCast(controller.eyes.position, controller.copStats.lookSphereRadius, controller.eyes.forward, out hit, controller.copStats.sightRange)
                && hit.collider.CompareTag(tagName))
            {
                controller.lastSeenEnemy = hit.collider.gameObject;
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }
}