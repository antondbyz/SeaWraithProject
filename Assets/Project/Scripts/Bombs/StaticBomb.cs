using UnityEngine;

public class StaticBomb : Bomb
{
    [SerializeField] private MinMaxRange<float> _scaleRange;

    private void Awake()
    {
        float randomScale = Random.Range(_scaleRange.Min, _scaleRange.Max);
        transform.localScale = new Vector2(randomScale, randomScale);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Crystal>() != null) Destroy(gameObject);
    }
}