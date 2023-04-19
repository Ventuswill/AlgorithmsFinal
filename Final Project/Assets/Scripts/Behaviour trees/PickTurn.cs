using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTurn : Task
{
    public override NodeResult Execute()
    {
        float rand = Random.Range(0, 3);
        if (rand == 0)
        {
            PatrolAI AI = tree.gameObject.GetComponent<PatrolAI>();
            AI.SetValue("TurnRequested", Turning.LEFT);
        }
        if(rand==1)
        {
            PatrolAI AI = tree.gameObject.GetComponent<PatrolAI>();
            AI.SetValue("TurnRequested", Turning.RIGHT);
        }
        if (rand == 2)
        {
            PatrolAI AI = tree.gameObject.GetComponent<PatrolAI>();
            AI.SetValue("TurnRequested", Turning.STRAIGHT);
        }
        return NodeResult.SUCCESS;
    }
}
