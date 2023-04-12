using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : BehaviorTree {
    public GameObject[] waypoints;
    public int index;
    public float Speed;
    public float TurnSpeed;
    public float Accuracy;
	//construct the actual tree
	void Start () {
        
        // create nodes
        Selector TreeRoot = new Selector();
        Sequence Patrol = new Sequence();
        MoveTo MoveToWP = new MoveTo();
        SelectNextGameObject PickNextWP = new SelectNextGameObject();
        PlayerChangeLane Change = new PlayerChangeLane();
        // create blackboard keys and initialize them with values
        // NOTE - SHOULD BE USING CONSTANTS
        TurnSpeed = 600.0f;
        Speed = 5.0f;
        Accuracy = 1.5f;
        SetValue("Waypoints", waypoints);
        SetValue("Waypoint", waypoints[0]);
        SetValue("Index", 0);
        SetValue("Speed", Speed);
        SetValue("TurnSpeed", TurnSpeed);
        SetValue("Accuracy", Accuracy); 
        SetValue("Direction", 1);
        SetValue("TurnRequested", Turning.LEFT);
        // set node parameters - connect them to the blackboard
        MoveToWP.TargetName = "Waypoint";
        PickNextWP.ArrayKey = "Waypoints";
        PickNextWP.GameObjectKey = "Waypoint";
        PickNextWP.DirectionKey = "Direction";
        PickNextWP.IndexKey = "Index";
        // connect nodes
        Patrol.children.Add(MoveToWP);
        Patrol.children.Add(PickNextWP);
        Patrol.children.Add(Change);
        TreeRoot.children.Add(Patrol);
        Patrol.tree = this;
        TreeRoot.tree = this;
        MoveToWP.tree = this;
        PickNextWP.tree = this;
        Change.tree = this;
        root = TreeRoot;
        
	}

    // we don't need an update - the base class will deal with that.
    // but, since we have one, we can use it to set some of the moveto parameters on the fly
    // which lets us tweak them in the inspector
    public override void Update()
    {
        SetValue("Speed", Speed);
        SetValue("TurnSpeed", TurnSpeed);
        SetValue("Accuracy", Accuracy);
        base.Update();
    }
}
