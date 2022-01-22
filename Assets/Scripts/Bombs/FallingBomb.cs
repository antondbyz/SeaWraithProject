using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBomb : Bomb
{
    [SerializeField] private MinMaxRange<float> _gravityRange;
    [SerializeField] private MinMaxRange<float> _torqueRange;

    private void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.gravityScale = Random.Range(_gravityRange.Min, _gravityRange.Max);

        float torque = Random.Range(_torqueRange.Min, _torqueRange.Max);
        bool flipTorque = Random.Range(0f, 1f) > 0.5f;
        if(flipTorque) torque = -torque;
        rigidbody.AddTorque(torque);
    }
}