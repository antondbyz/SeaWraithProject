using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public const string PREMIUM_ID = "com.eighter.seawraith.premium";
    public static event System.Action<Product> PurchaseCompleted;
    public static bool IsPremiumPurchased => _premiumProduct.hasReceipt;
    private static Product _premiumProduct;
    private static IStoreController _controller;
     
    public static void InitiatePurchase(string productId)
    {
        _controller.InitiatePurchase(productId);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _controller = controller;
        for(int i = 0; i < _controller.products.all.Length; i++)
        {
            switch(_controller.products.all[i].definition.id)
            {
                case PREMIUM_ID:
                    _premiumProduct = _controller.products.all[i];
                    break;
            }
        }
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        PurchaseCompleted?.Invoke(purchaseEvent.purchasedProduct);
        return PurchaseProcessingResult.Complete;
    }

    private void Awake()
    {
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(PREMIUM_ID, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }
}
