using UnityEngine;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{
    [SerializeField] private GameObject _premiumButton;
    [SerializeField] private GameObject _shopMainMenu;
    [SerializeField] private GameObject _premiumMenu;
    private WaitForSecondsRealtime _purchaseCompleteDelay = new WaitForSecondsRealtime(0.1f);

    public void PurchasePremium()
    {
        IAPManager.InitiatePurchase(IAPManager.PREMIUM_ID);
    }

    private void Awake()
    {
        UpdateUI();
    }

    private void OnEnable()
    {
        IAPManager.PurchaseCompleted += OnPurchaseCompleted;
    }

    private void OnDisable()
    {
        IAPManager.PurchaseCompleted -= OnPurchaseCompleted;
    }

    private void OnPurchaseCompleted(Product product)
    {
        switch(product.definition.id)
        {
            case IAPManager.PREMIUM_ID:
                UpdateUI();
                _shopMainMenu.SetActive(true);
                _premiumMenu.SetActive(false);
                break;
        }
    }

    private void UpdateUI()
    {
        _premiumButton.SetActive(!IAPManager.IsPremiumPurchased);
    }
}
