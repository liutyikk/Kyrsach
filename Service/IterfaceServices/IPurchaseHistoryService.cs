using Kyrsach.Entities;

namespace Kyrsach.Service;

public interface IPurchaseHistoryService
{
    void PurchaseProduct(User user, int productId, int quantity);
    List<PurchaseHistory> GetPurchaseHistory(User user);
}