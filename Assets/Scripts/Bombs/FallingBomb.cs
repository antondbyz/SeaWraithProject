using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBomb : MonoBehaviour
{
    [Header("Torque range")]
    [SerializeField] private float _minTorque;
    [SerializeField] private float _maxTorque;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float torque = Random.Range(_minTorque, _maxTorque);
        bool flipTorque = Random.Range(0f, 1f) > 0.5f;
        if(flipTorque) torque = -torque;
        _rigidbody.AddTorque(torque);
    }
}
