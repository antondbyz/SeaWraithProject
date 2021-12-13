using UnityEngine;

public class StaticBomb : MonoBehaviour
{
    [SerializeField] private float _maxScale = 2f;
    [SerializeField] private float _minScale = 1;

    private void Awake()
    {
        float randomScale = Random.Range(_minScale, _maxScale);
        transform.localScale = new Vector2(randomScale, randomScale);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Pickable"))
        {
            Destroy(gameObject);
        }
    }
}