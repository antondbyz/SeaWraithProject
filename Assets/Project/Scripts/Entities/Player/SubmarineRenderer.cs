using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SubmarineRenderer : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = SubmarinePaintsManager.CurrentPaintObject.Paint;
    }
}
