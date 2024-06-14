using BattleDrakeCreations.BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoUnit : MonoBehaviour, IBehaviorTreeAgent
{
    GameObject IBehaviorTreeAgent.AgentData { get => this.gameObject; }
}
