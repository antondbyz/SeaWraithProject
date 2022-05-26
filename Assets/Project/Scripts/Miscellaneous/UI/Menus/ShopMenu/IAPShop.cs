using UnityEngine;

public class IAPShop : MonoBehaviour
{
    [SerializeField] private GameObject _shopMainMenu;
    [SerializeField] private GameObject _premiumMenu;

    public void PurchasePremium()
    {
        IAPManager.InitiatePurchase(IAPManager.PREMIUM_ID);
    }

    private void OnEnable()
    {
        IAPManager.PremiumPurchased += OnPremiumPurchased;
    }

    private void OnDisable()
    {
        IAPManager.PremiumPurchased -= OnPremiumPurchased;
    }

    private void OnPremiumPurchased()
    {
        _shopMainMenu.SetActive(true);
        _premiumMenu.SetActive(false);
    }
}
