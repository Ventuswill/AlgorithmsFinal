using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDriver : BehaviorTree
{
    // Start is called before the first frame update
    void Start()
    {
        // create nodes
        Selector TreeRoot = new Selector();
        Sequence seq = new Sequence();
        Wait timer = new Wait();
        PickTurn turn = new PickTurn();
        // create blackboard keys and initialize them with values
        // NOTE - SHOULD BE USING CONSTANTS
        SetValue("timer", 3.0f);

        timer.TimeToWaitKey = "timer";
        TreeRoot.children.Add(seq);
        seq.children.Add(turn);
        seq.children.Add(timer);
        TreeRoot.tree = this;
        seq.tree = this;
        timer.tree = this;
        turn.tree = this;
        root = TreeRoot;
    }


    

    
   


    
}



