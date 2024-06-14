using UnityEngine;

namespace BattleDrakeCreations.BehaviorTree
{
    public class CompareBBEntries : DecoratorNode
    {
        [SerializeField] private string _stringKey1;
        [SerializeField] private string _stringKey2;

        [SerializeField] private AnyValue.ValueType _valueType;

        public override string title { get => "Compare Blackboard Entries"; }
        public override string description { get => $"Compare: {_stringKey1} : {_stringKey2}"; }

        private BlackboardKey _blackboardKey1;
        private BlackboardKey _blackboardKey2;

        protected override NodeResult OnEvaluate()
        {
            _result = NodeResult.Running;

            if (!_blackboard.AreKeyValueTypesEqual(_blackboardKey1, _blackboardKey2))
            {
                Debug.LogWarning("Mismatching Value Types");
                _result = NodeResult.Failed;
            }

            if (AreValuesEqual())
                _result = _child.Evaluate();

            return _result;
        }

        protected override void OnStart()
        {
            _blackboardKey1 = _blackboard.GetOrRegisterKey(_stringKey1);
            _blackboardKey2 = _blackboard.GetOrRegisterKey(_stringKey2);
        }

        protected override void OnStop()
        {
        }

        private bool AreValuesEqual()
        {
            //Add additional type checks here after adding to AnyValue. 
            switch (_valueType)
            {
                case AnyValue.ValueType.Int:
                    if (_blackboard.AreValuesEqual<int>(_blackboardKey1, _blackboardKey2))
                        return true;
                    break;
                case AnyValue.ValueType.Float:
                    if (_blackboard.AreValuesEqual<float>(_blackboardKey1, _blackboardKey2))
                        return true;
                    break;
                case AnyValue.ValueType.Bool:
                    if (_blackboard.AreValuesEqual<bool>(_blackboardKey1, _blackboardKey2))
                        return true;
                    break;
                case AnyValue.ValueType.String:
                    if (_blackboard.AreValuesEqual<string>(_blackboardKey1, _blackboardKey2))
                        return true;
                    break;
                case AnyValue.ValueType.Vector3:
                    if (_blackboard.AreValuesEqual<Vector3>(_blackboardKey1, _blackboardKey2))
                        return true;
                    break;
                case AnyValue.ValueType.Transform:
                    if (_blackboard.AreValuesEqual<Transform>(_blackboardKey1, _blackboardKey2))
                        return true;
                    break;
                case AnyValue.ValueType.GameObject:
                    if (_blackboard.AreValuesEqual<GameObject>(_blackboardKey1, _blackboardKey2))
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }
    }
}