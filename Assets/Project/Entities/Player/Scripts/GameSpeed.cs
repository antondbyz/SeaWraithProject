using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public float Speed => _speed;

    [SerializeField] private float _accelerationRate;

    private float _speed;

    private void Update()
    {
        _speed = Mathf.MoveTowards(_speed, 1, _accelerationRate * Time.deltaTime);
    }
}
