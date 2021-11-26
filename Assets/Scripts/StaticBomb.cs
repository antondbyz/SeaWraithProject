using UnityEngine;

public class StaticBomb : MonoBehaviour
{
    [SerializeField] private float _maxScale = 2f;
    [SerializeField] private float _minScale = 1;

    private void Start()
    {
        float randomScale = Random.Range(_minScale, _maxScale);
        transform.localScale = new Vector2(randomScale, randomScale);
    }
}