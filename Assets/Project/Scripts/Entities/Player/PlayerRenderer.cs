using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerRenderer : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = SubmarinesManager.CurrentSubmarine.Paint;
    }
}
