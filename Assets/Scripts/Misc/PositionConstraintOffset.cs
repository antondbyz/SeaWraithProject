using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(PositionConstraint))]
public class PositionConstraintOffset : MonoBehaviour
{
    [SerializeField] private MinMaxRange<Vector2> _offsetRange; 

    private PositionConstraint _constraint;

    private void Start()
    {
        _constraint = GetComponent<PositionConstraint>();
    }

    private void Update()
    {
        Vector2 offset = Vector2.Lerp(_offsetRange.Min, _offsetRange.Max, HardnessManager.Instance.GameHardness);
        _constraint.translationOffset = offset;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Transform sourceTransform = GetComponent<PositionConstraint>().GetSource(0).sourceTransform;
        if(sourceTransform != null)
        {
            Gizmos.DrawSphere(_offsetRange.Min + (Vector2)sourceTransform.position, 0.5f);
            Gizmos.DrawSphere(_offsetRange.Max + (Vector2)sourceTransform.position, 0.5f);
        }
    }
}