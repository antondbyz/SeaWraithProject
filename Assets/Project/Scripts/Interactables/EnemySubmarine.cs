using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemySubmarine : MonoBehaviour, ISpawnable
{
    private MovementController _movement;

    public void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        _movement.UpdateMovement();
    }

    private void Awake()
    {
        _movement = GetComponent<MovementController>();
    }
}
