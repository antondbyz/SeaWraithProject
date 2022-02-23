using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public float Speed { get; private set; }

    [SerializeField] private float _accelerationRate;

    private void Update()
    {
        Speed = Mathf.MoveTowards(Speed, 1, _accelerationRate * Time.deltaTime);
    }
}
