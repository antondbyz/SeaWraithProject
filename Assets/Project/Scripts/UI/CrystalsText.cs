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
        PlayerManager.CrystalsChanged += UpdateText;
    }

    private void OnDisable()
    {
        PlayerManager.CrystalsChanged -= UpdateText;
    }

    private void UpdateText() 
    {
        _text.text = PlayerManager.CrystalsAmount.ToString();
    }
}
