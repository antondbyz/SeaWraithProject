using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineItem : SelectableItem
{
    public SubmarineObject Submarine { get; private set; }
    public int Index { get; private set; }
    public bool IsBought => SubmarinesManager.IsItemBought(this);
    public bool IsCurrent => SubmarinesManager.CurrentSubmarineIndex == Index;
    public bool IsEnoughtCrystalsToBuy => PlayerProfile.CrystalsAmount >= Submarine.Price;
    [SerializeField] private Image _submarinePreview;
    [SerializeField] private TMP_Text _statsText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private GameObject _priceLabel;
    [SerializeField] private GameObject _boughtLabel;
    [SerializeField] private GameObject _usingLabel;
    private bool _isInitialized;

    public void Initialize(SubmarineObject submarine, int index)
    {
        _submarinePreview.sprite = submarine.Paint;
        _priceText.text = $"{submarine.Price}<sprite name=Crystal>";
        _statsText.text = $"<size=90%>Armor:</size> <b>{submarine.Armor}</b>\t" +
            $"<size=90%>Mobility:</size> <b>{submarine.Mobility}</b>";
        Submarine = submarine;
        Index = index;
        UpdateUI();
        _isInitialized = true;
    }

    private void OnEnable()
    {
        if(_isInitialized) UpdateUI();
        SubmarinesManager.Changed += UpdateUI;
        PlayerProfile.CrystalsChanged += UpdateUI;
    }

    private void OnDisable()
    {
        SubmarinesManager.Changed -= UpdateUI;
        PlayerProfile.CrystalsChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _priceText.color = IsEnoughtCrystalsToBuy ? Color.green : Color.red;
        _priceLabel.SetActive(!IsBought);
        _boughtLabel.SetActive(IsBought && !IsCurrent);
        _usingLabel.SetActive(IsCurrent);
    }
}
