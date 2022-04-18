using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaintItem : MonoBehaviour
{
    public int Index { get; private set; }
    [SerializeField] private Image _submarinePaintPreview;
    [Header("Price")]
    [SerializeField] private GameObject _priceLabel;
    [SerializeField] private TMP_Text _priceText;
    [Space]
    [SerializeField] private GameObject _boughtLabel;
    [SerializeField] private GameObject _currentLabel;

    public void Initialize(SubmarinePaintObject paintObject, int index)
    {
        _submarinePaintPreview.sprite = paintObject.Paint;
        _priceText.text = $"{paintObject.Price}<sprite name=Crystal>";
        Index = index;
        UpdateUI();
    }

    private void UpdateUI()
    {
        bool isBought = SubmarinePaintsManager.BoughtObjects[Index];
        bool isCurrent = SubmarinePaintsManager.CurrentPaintObjectIndex == Index;
        _priceLabel.SetActive(!isBought);
        _boughtLabel.SetActive(isBought && !isCurrent);
        _currentLabel.SetActive(isCurrent);
    }
}
