using UnityEngine;

public class StaticBomb : Bomb
{
    [SerializeField] private MinMaxRange _scaleRange;

    private void Start()
    {
        float randomScale = Random.Range(_scaleRange.Min, _scaleRange.Max);
        transform.localScale = new Vector2(randomScale, randomScale);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
}