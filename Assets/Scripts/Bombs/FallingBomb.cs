using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBomb : Bomb
{
    [Header("Gravity range")]
    [SerializeField] private float _minGravity;
    [SerializeField] private float _maxGravity;
    [Header("Torque range")]
    [SerializeField] private float _minTorque;
    [SerializeField] private float _maxTorque;

    private void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.gravityScale = Random.Range(_minGravity, _maxGravity);

        float torque = Random.Range(_minTorque, _maxTorque);
        bool flipTorque = Random.Range(0f, 1f) > 0.5f;
        if(flipTorque) torque = -torque;
        rigidbody.AddTorque(torque);
    }
}