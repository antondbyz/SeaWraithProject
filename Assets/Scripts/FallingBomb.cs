using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBomb : MonoBehaviour
{
    [System.Serializable]
    private struct SpeedRange
    {
        public float Max;
        public float Min;
    }

    [Header("Fall speed range")]
    [SerializeField] private SpeedRange _maxFallSpeedRange = new SpeedRange();
    [SerializeField] private SpeedRange _minFallSpeedRange = new SpeedRange();
    [Header("Torque range")]
    [SerializeField] private float _minTorque;
    [SerializeField] private float _maxTorque;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float minGravity = Mathf.Lerp(_minFallSpeedRange.Min, _maxFallSpeedRange.Min, GameManager.Instance.GameSpeedInterpolationPoint);
        float maxGravity = Mathf.Lerp(_minFallSpeedRange.Max, _maxFallSpeedRange.Max, GameManager.Instance.GameSpeedInterpolationPoint);
        _rigidbody.gravityScale = Random.Range(minGravity, maxGravity);

        float torque = Random.Range(_minTorque, _maxTorque);
        bool flipTorque = Random.Range(0f, 1f) > 0.5f;
        if(flipTorque) torque *= -1;
        _rigidbody.AddTorque(torque);
    }
}
