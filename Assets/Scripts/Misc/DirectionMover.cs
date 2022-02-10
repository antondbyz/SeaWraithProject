using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectionMover : MonoBehaviour
{
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private MinMaxRange<float> _speedRange;

    private void Awake()
    {
        PlayerController controller = ObjectsFinder.FindPlayer().GetComponent<PlayerController>();
        float speed = Mathf.Lerp(_speedRange.Min, _speedRange.Max, controller.SpeedInterpPoint);
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(_moveDirection) * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(transform.position, _moveDirection));
    }
}