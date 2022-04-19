using TMPro;
using UnityEngine;

public class CrystalsLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text _crystalsText;
    [SerializeField] private bool _selfUpdate = true;

    private void OnEnable()
    {
        OnCrystalsChanged();
        PlayerManager.CrystalsChanged += OnCrystalsChanged;
    }

    private void OnDisable()
    {
        PlayerManager.CrystalsChanged -= OnCrystalsChanged;
    }

    private void OnCrystalsChanged() 
    {
        if(_selfUpdate)
        {
            _crystalsText.text = PlayerManager.CrystalsAmount.ToString();
        }
    }
}
