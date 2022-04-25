using UnityEngine;

public class StaticBomb : Bomb, ISpawnable
{
    [SerializeField] private MinMaxRange<float> _scaleRange;

    public override void Disappear()
    {
        gameObject.SetActive(false);
    }
    
    protected override void Initialize()
    {
        float randomScale = Random.Range(_scaleRange.Min, _scaleRange.Max);
        transform.localScale = new Vector2(randomScale, randomScale);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Crystal>() != null) Disappear();
    }
}