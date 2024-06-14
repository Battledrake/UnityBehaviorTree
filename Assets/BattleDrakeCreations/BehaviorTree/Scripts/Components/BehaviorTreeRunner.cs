using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeCreations.BehaviorTree
{
    public class BehaviorTreeRunner : MonoBehaviour
    {
        [SerializeField] private BehaviorTree _behaviorTree;
        [SerializeField] private float _delayBetweenEvaluations = 0.0f;

        public BehaviorTree GetBehaviorTree() { return _behaviorTree; }

        private void Awake()
        {
            if (_behaviorTree != null)
            {
                _behaviorTree = _behaviorTree.Clone();

                _behaviorTree.Bind(GetComponent<IBehaviorTreeAgent>());
            }
        }

        private void Start()
        {
            StartCoroutine(RunAILogic());
        }

        private IEnumerator RunAILogic()
        {
            NodeResult treeResult = NodeResult.Running;
            do
            {
                treeResult = _behaviorTree.ExecuteTree();
                yield return new WaitForSeconds(_delayBetweenEvaluations);
            } while (treeResult != NodeResult.Succeeded);
        }
    }
}
