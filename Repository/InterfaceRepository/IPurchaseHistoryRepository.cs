using Kyrsach.Entities;

namespace Kyrsach.Repository;

public interface IPurchaseHistoryRepository
{
    void Create(PurchaseHistory purchase);
    List<PurchaseHistory> ReadByUserId(int userId);
}