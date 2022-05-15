using UnityEngine;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{
    private const string PREMIUM_ID = "com.eighter.seawraith.premium";

    public void OnPurchaseComplete(Product product)
    {
        switch(product.definition.id)
        {
            case PREMIUM_ID:
                break;
        }
    }
}
