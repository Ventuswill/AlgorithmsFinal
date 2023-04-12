using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDriver : BehaviorTree
{
    // Start is called before the first frame update
    void Start()
    {
        // create nodes
        Wait timer = new Wait();
        Task PickTurn = new Task();
        // create blackboard keys and initialize them with values
        // NOTE - SHOULD BE USING CONSTANTS
        SetValue("timer", 3.0f);
        int rand = Random.Range(0, 2);
        SetValue("PickTurn", rand);
    }


    /*

    // Update is called once per frame
    void Update()
    {
        PatrolAI ai = tree.gameObject.GetComponent<PatrolAI>();
        SetValue("timer", 3.0f);
        int rand = Random.Range(0, 2);

        if (PickTurn==0)
        {
            ai.SetValue("TurnRequested", Turning.LEFT);
        }
    }


    */
}



