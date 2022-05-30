using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineItem : SelectableItem
{
    public SubmarineObject Submarine { get; private set; }
    public int Index { get; private set; }
    public bool IsBought => SubmarinesManager.IsSubmarineBought(Index);
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
        LocalesManager.LanguageChanged += UpdateUI;
    }

    private void OnDisable()
    {
        SubmarinesManager.Changed -= UpdateUI;
        PlayerProfile.CrystalsChanged -= UpdateUI;
        LocalesManager.LanguageChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        _submarinePreview.sprite = Submarine.Paint;
        _priceText.color = IsEnoughtCrystalsToBuy ? Color.green : Color.red;
        _priceText.text = $"{Submarine.Price}<sprite name=Crystal>";
        _statsText.text = $"<size=90%>{LocalesManager.GetLocalizedText("_armor")}:</size> <b>{Submarine.Armor}</b>\t" +
            $"<size=90%>{LocalesManager.GetLocalizedText("_mobility")}:</size> <b>{Submarine.Mobility}</b>";
        _priceLabel.SetActive(!IsBought);
        _boughtLabel.SetActive(IsBought && !IsCurrent);
        _usingLabel.SetActive(IsCurrent);
    }
}
