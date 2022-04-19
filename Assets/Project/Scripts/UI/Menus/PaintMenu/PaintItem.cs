using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaintItem : SelectableItem
{
    public SubmarinePaintObject PaintObject { get; private set; }
    public int Index { get; private set; }
    public bool IsBought => SubmarinePaintsManager.IsItemBought(this);
    public bool IsCurrent => SubmarinePaintsManager.CurrentPaintItemIndex == Index;
    public bool IsEnoughtCrystalsToBuy => PlayerManager.CrystalsAmount >= PaintObject.Price;
    [SerializeField] private Image _submarinePaintPreview;
    [Header("Price")]
    [SerializeField] private GameObject _priceLabel;
    [SerializeField] private TMP_Text _priceText;
    [Space]
    [SerializeField] private GameObject _boughtLabel;
    [SerializeField] private GameObject _currentLabel;
    private bool _isInitialized;

    public void Initialize(SubmarinePaintObject paintObject, int index)
    {
        _submarinePaintPreview.sprite = paintObject.Paint;
        _priceText.text = $"{paintObject.Price}<sprite name=Crystal>";
        PaintObject = paintObject;
        Index = index;
        UpdateUI();
        _isInitialized = true;
    }

    private void OnEnable()
    {
        if(_isInitialized) UpdateUI();
        SubmarinePaintsManager.ItemsChanged += UpdateUI;
        PlayerManager.CrystalsChanged += UpdateUI;
    }

    private void OnDisable()
    {
        SubmarinePaintsManager.ItemsChanged -= UpdateUI;
        PlayerManager.CrystalsChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _priceText.color = IsEnoughtCrystalsToBuy ? Color.green : Color.red;
        _priceLabel.SetActive(!IsBought);
        _boughtLabel.SetActive(IsBought && !IsCurrent);
        _currentLabel.SetActive(IsCurrent);
    }
}
