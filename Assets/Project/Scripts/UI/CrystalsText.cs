using TMPro;
using UnityEngine;

public class CrystalsText : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        UpdateText();
        PlayerProfile.CrystalsChanged += UpdateText;
    }

    private void OnDisable()
    {
        PlayerProfile.CrystalsChanged -= UpdateText;
    }

    private void UpdateText() 
    {
        _text.text = PlayerProfile.CrystalsAmount.ToString();
    }
}
