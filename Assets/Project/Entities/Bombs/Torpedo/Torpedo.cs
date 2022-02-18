using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : Bomb
{
    [SerializeField] private MinMaxRange<float> _speedRange;

    private void Awake()
    {
        PlayerController controller = ObjectsFinder.FindPlayer().GetComponent<PlayerController>();
        float speed = Mathf.Lerp(_speedRange.Min, _speedRange.Max, controller.SpeedInterpPoint);
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
}