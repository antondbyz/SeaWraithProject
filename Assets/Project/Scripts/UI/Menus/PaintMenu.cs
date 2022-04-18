using UnityEngine;

public class PaintMenu : MonoBehaviour
{
    [SerializeField] private Transform _paintItemsParent;
    [SerializeField] private PaintItem _paintItem;

    private void Awake()
    {
        for(int i = 0 ; i < SubmarinePaintsManager.PaintObjects.Length; i++)
        {
            PaintItem newItem = Instantiate(_paintItem, _paintItemsParent);
            newItem.Initialize(SubmarinePaintsManager.PaintObjects[i], i);
        }
    }
}
