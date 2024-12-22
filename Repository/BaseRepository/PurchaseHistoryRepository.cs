using Kyrsach.Entities;

namespace Kyrsach.Repository;

public class PurchaseHistoryRepository : IPurchaseHistoryRepository
{
    private readonly DbContext _db;

    public PurchaseHistoryRepository(DbContext db)
    {
        _db = db;
    }

    public void Create(PurchaseHistory purchase) => _db.PurchaseHistories.Add(purchase);
    public List<PurchaseHistory> ReadByUserId(int userId) => _db.PurchaseHistories.Where(p => p.UserId == userId).ToList();
}