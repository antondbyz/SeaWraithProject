using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(PositionConstraint))]
public class PositionConstraintOffset : MonoBehaviour
{
    [SerializeField] private MinMaxRange<Vector2> _offsetRange; 

    private PositionConstraint _constraint;
    private PlayerController _playerController;

    private void Awake()
    {
        _constraint = GetComponent<PositionConstraint>();
        _playerController = ObjectsFinder.FindPlayer().GetComponent<PlayerController>();
    }

    private void Update()
    {
        Vector2 offset = Vector2.Lerp(_offsetRange.Min, _offsetRange.Max, _playerController.SpeedInterpPoint);
        _constraint.translationOffset = offset;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Transform sourceTransform = GetComponent<PositionConstraint>().GetSource(0).sourceTransform;
        if(sourceTransform != null)
        {
            Vector3 min = _offsetRange.Min + (Vector2)sourceTransform.position;
            Vector3 max = _offsetRange.Max + (Vector2)sourceTransform.position;
            Gizmos.DrawSphere(min, 0.5f);
            Gizmos.DrawSphere(max, 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(min, max);
        }
    }
}