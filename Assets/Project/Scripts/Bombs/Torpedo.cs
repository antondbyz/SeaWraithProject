using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : Bomb
{
    [SerializeField] private MinMaxRange<float> _speedRange;

    private void Awake()
    {
        GameSpeed gameSpeed = ObjectsFinder.FindPlayer().GetComponent<GameSpeed>();
        float speed = Mathf.Lerp(_speedRange.Min, _speedRange.Max, gameSpeed.Speed);
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
}